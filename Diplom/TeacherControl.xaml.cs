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
    /// Логика взаимодействия для TeacherControl.xaml
    /// </summary>
    public partial class TeacherControl : UserControl
    {
        public ContentPresenter presenter;
        public TeacherControl()
        {
            InitializeComponent();
            FindLike("SELECT * FROM Persons WHERE ROLE = 0");
        }

        private void FindLike(string execcomm) // Обновление вывода
        {
            MainWindow.usersInfo.Clear(); // очищаем всё, если там что-то будет
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DiplomUsers;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = execcomm;
                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        MainWindow.UserInfo fileInfo = new MainWindow.UserInfo();
                        fileInfo.Id = Convert.ToInt32(reader.GetValue(0));
                        fileInfo.Login = Convert.ToString(reader.GetValue(1));
                        fileInfo.Name = Convert.ToString(reader.GetValue(3));
                        fileInfo.Surname = Convert.ToString(reader.GetValue(4));
                        fileInfo.Dadname = Convert.ToString(reader.GetValue(5));
                        fileInfo.Progress = Convert.ToInt32(reader.GetValue(7));
                        FileInfoView.ItemsSource = MainWindow.usersInfo;
                        MainWindow.usersInfo.Add(fileInfo);
                    }
                }

                reader.Close();

            }
        }

        private void ZeroProgress_Context(object sender, RoutedEventArgs e)
        {

        }
    }
}
