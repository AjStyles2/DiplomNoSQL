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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : UserControl
    {
        public ContentPresenter presenter;

        string CurLogin = "";       //текущий логин
        string CurPassword = "";    //текущий пароль
        string CurRole = "";        //текущая роль

        string CurCaptcha = "";     //текущая капча


        public Authorization()
        {
            InitializeComponent();
            Captcha();

        }

        private void Login_Btn(object sender, RoutedEventArgs e)
        {
            if (CaptchaTB.Text == CurCaptcha)
            {
                FindUser(LoginTB.Text, PasswordTB.Text); //Вызываем и передаём аргвы в метод на поиск логина и пароля
                Captcha(); // меняем капчу от ботов
            }
            else
            {
                MessageBox.Show("Капча введена неверно");
                CaptchaTB.Background = Brushes.LightPink; // подсветка окна капчи при неверном вводе
            }

            //CustomerPage UserPage = new CustomerPage();
            //frame.Content = UserPage;
        }

        private void Register_Btn(object sender, RoutedEventArgs e)
        {
            UserRegistration firstpage = new UserRegistration { presenter = this.presenter };
            presenter.Content = firstpage;
        }

        private void FindUser(string log, string pass) // метод с аргументами log и pass для поиска юзера из БД
        {
            //MainWindow.studInfo.Clear(); // очищаем всё, если там что-то будет
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DiplomUsers;Integrated Security=True"; //подключение к бд
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM Persons WHERE [Login] = '" + log + "' AND [Password] = '" + pass + "';"; //выполняем запрос на поиск логина и пароля в БД
                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если запрос нашёл записи
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        CurLogin = Convert.ToString(reader.GetValue(0));
                        CurPassword = Convert.ToString(reader.GetValue(1));
                        CurRole = Convert.ToString(reader.GetValue(2));
                    }

                    //MainWindow.ShowExitButton(true); // Показываем кнопку выхода

                    MainPage usa = new MainPage { presenter = this.presenter };
                    presenter.Content = usa;

                    //switch (CurRole) //проверка на роль у юзера и открытие нужной ему формы
                    //{
                    //    case "Директор":
                    //        //MainWindow DirPage = new MainWindow() { frame = this.frame }; // то что в {} это типо для передачи инфы на след. страницу, чтоб типо она не пустая была
                    //        //frame.Content = DirPage;
                    //        break;
                    //    default:
                    //        //MessageBox.Show("Ваша роль неопределена, свяжитесь с администратором", "ОШИБКА");
                    //        //MainWindow.ShowExitButton(false);
                    //        break;
                    //}
                }
                else
                {
                    MessageBox.Show("Логин или пароль неверны", "ОШИБКА");
                }

                reader.Close();

            }
        }

        private void Captcha()
        {
            CurCaptcha = ""; //обнуляем если она была сгенерирована до этого

            Random rand = new Random(); // генератор рандома
            int n = 4; //кол-во букв
            char[] a = new char[5];
            for (int i = 0; i < n; i++)
            {
                if (rand.Next(0, 4) == 0) // средний шанс выпадения числа в капче
                {
                    a[i] = (char)rand.Next(0x0030, 0x003A); // это диапазон генерируемых чисел
                }
                else
                {
                    a[i] = (char)rand.Next(0x0041, 0x005A); // это диапазон генерируемых кодов (см. таблицу Unicode для кириллицы ) от прописной "А"(шестнадцатеричный код 0x410) до строчной "я"(шестнадцатеричный код 0x44F)
                }
                CurCaptcha = CurCaptcha + a[i];
            }
            CapchaLL.Content = CurCaptcha; //выводим капчу
        }

        private void RefreshCaptcha_Btn(object sender, RoutedEventArgs e) //кнопка для обновления капчи если сложная
        {
            Captcha(); //просто вызов новой генерации капчи
        }
    }
}
