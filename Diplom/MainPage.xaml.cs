using Diplom.Droppers;
using Diplom.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {

        public ContentPresenter presenter;
        public MainPage()
        {
            InitializeComponent();



            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Exercise 1: Request SET", new UserControlSet()));
            menuRegister.Add(new SubItem("Exercise 2: Request GET", new UserControlGet()));
            menuRegister.Add(new SubItem("Exercise 3: Request INCR", new WpfControls.UserControlIncr()));
            menuRegister.Add(new SubItem("Exercise 4: Request DECR", new WpfControls.UserControlDecr()));
            var item1 = new ItemMenu("REDIS Strings", menuRegister);

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("RPUSH"));
            menuSchedule.Add(new SubItem("LPUSH"));
            menuSchedule.Add(new SubItem("LRANGE"));
            menuSchedule.Add(new SubItem("RPOP"));
            var item2 = new ItemMenu("Lists", menuSchedule);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("HMSET"));
            menuReports.Add(new SubItem("HGET"));
            menuReports.Add(new SubItem("HGETALL"));
            var item3 = new ItemMenu("Hashes", menuReports);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("PFADD"));
            menuExpenses.Add(new SubItem("PFCOUNT"));
            var item4 = new ItemMenu("HyperLogLogs", menuExpenses);

            var menuFinancial = new List<SubItem>();
            menuFinancial.Add(new SubItem("XLEN"));
            var item5 = new ItemMenu("Streams", menuFinancial);

            Menu.Children.Add(new UserControlMenuItem(item1, this)); // добавляем раскрывающийся пункт к StackPanel
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
            Menu.Children.Add(new UserControlMenuItem(item5, this));

            DataContext = new MainViewModel();

            //MessageBox.Show(Convert.ToString(CountFinishedTests()));
            int cntProg = CountFinishedTests();
            ProgressRect.Width = cntProg * 5;
            //Authorization firstpage = new Authorization();
            //firstpage.presenter = MainContent;
            //MainContent.Content = firstpage;


        }

        internal void SwitchScreen(object sender) // метод для смены отображающейся страницы
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private int CountFinishedTests() // метод с аргументами log и pass для поиска юзера из БД
        {
            //MainWindow.studInfo.Clear(); // очищаем всё, если там что-то будет
            int count = 0;
            
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DiplomUsers;Integrated Security=True"; //подключение к бд
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT COUNT(ID_Ex) FROM Results WHERE [ID_Stud] = 1"; //выполняем запрос на поиск прогресса пользователя
                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если запрос нашёл записи
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        count = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                else
                {
                    MessageBox.Show("Логин или пароль неверны", "ОШИБКА");
                }

                reader.Close();

            }
            return count;
        }
    }
}
