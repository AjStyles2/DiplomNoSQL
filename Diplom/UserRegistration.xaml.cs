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
    /// Логика взаимодействия для UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : UserControl
    {

        public ContentPresenter presenter;
        public UserRegistration()
        {
            InitializeComponent();
        }

        private void Register_Btn(object sender, RoutedEventArgs e) //Кнопка регистрации
        {
            if (LoginTB.Text.Length > 3)
            {
                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DiplomUsers;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM [Persons] WHERE Login = '" + LoginTB.Text + "'"; //Делаем запрос на проверку есть ли такой логин уже
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если есть данные
                    {
                        MessageBox.Show("Такой логин уже занят", "ОШИБКА");
                        LoginTB.Background = Brushes.LightPink; // подсветка поля логина при неверном вводе
                    }
                    else
                    {
                        bool PassHasDigit = false;
                        bool ContainsSign = false;
                        int SameSymbs = 1;
                        if (PasswordTB.Text.Length >= 6)
                        {
                            for (int i = 0; i < PasswordTB.Text.Length; i++) // минус 1 для избежания Индекса вне диапазона (убран)
                            {
                                if (Char.IsDigit(PasswordTB.Text[i])) //для проверки на есть ли цифра в пароле
                                {
                                    PassHasDigit = true;
                                }
                                if (PasswordTB.Text[i] == '*' | PasswordTB.Text[i] == '&' | PasswordTB.Text[i] == '{' | PasswordTB.Text[i] == '}' | PasswordTB.Text[i] == '|' | PasswordTB.Text[i] == '+') //для проверки на есть ли символ из набора
                                {
                                    ContainsSign = true;
                                }
                                try
                                {
                                    if (PasswordTB.Text[i] == PasswordTB.Text[i + 1])
                                    {
                                        SameSymbs = SameSymbs + 1;
                                    }
                                    else
                                    {
                                        if (SameSymbs < 3)
                                        {
                                            SameSymbs = 1;
                                        }
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    //if (PasswordTB.Text[i] == PasswordTB.Text[i - 1])
                                    //{
                                    // //SameSymbs = SameSymbs + 1;
                                    //}
                                }
                            }
                            if (PassHasDigit)
                            {
                                if (SameSymbs >= 3)
                                {
                                    MessageBox.Show("Не должно быть 3 и более подряд идущих одинаковых символа", "ОШИБКА");
                                }
                                else
                                {
                                    if (ContainsSign)
                                    {
                                        AddNewUser(LoginTB.Text, PasswordTB.Text, NameTB.Text, SurnameTB.Text, DadnameTB.Text); // вызываем метод на добавление юзера и передаём в него аргументы
                                    }
                                    else
                                    {
                                        MessageBox.Show("Отсутствует символ из набора *&{}|+", "ОШИБКА");
                                        PasswordTB.Background = Brushes.LightPink; // подсветка красным поля пароля если ошибка
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пароль должен содержать цифру", "ОШИБКА");
                                PasswordTB.Background = Brushes.LightPink; // подсветка красным поля пароля если ошибка
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароль должен быть от 6 до 18 символов", "ОШИБКА");
                            PasswordTB.Background = Brushes.LightPink; // подсветка красным поля пароля если ошибка
                        }
                    }

                    reader.Close();

                }
            }
            else
            {
                MessageBox.Show("Логин должен быть больше 3 символов", "ОШИБКА");
                LoginTB.Background = Brushes.LightPink; // подсветка поля логина при неверном вводе
            }
        }

        private void AddNewUser(string log, string pass, string name, string surname, string dadname) //метод на добавление в SQL нового USER
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DiplomUsers;Integrated Security=True";
            string sqlExpression = "INSERT INTO [Persons](Login, Password, Name, Surname, Dadname, Role ) VALUES ('" + log + "', '" + pass + "', '" + name + "', '" + surname + "','" + dadname + "', 0)";
            MessageBox.Show(sqlExpression);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                MessageBox.Show("Добавлено объектов: " + Convert.ToString(number));

                //CustomerPage UserPage = new CustomerPage() { frame = this.frame }; // то что в {} это типо для передачи инфы на след. страницу, чтоб типо она не пустая была
                //frame.Content = UserPage;
                //MainWindow.ShowExitButton(true); // Показываем кнопку выхода
            }

        }

        private void Cancel_Btn(object sender, RoutedEventArgs e)
        {
            Authorization firstpage = new Authorization { presenter = this.presenter };
            presenter.Content = firstpage;
        }












        //////////////////////////////////// ЧАСТЬ КОДА(ИВЕНТЫ) ///////////////////////////////////////////////////////////////////////////////////////////////////

        private void LoginTB_TextChanged(object sender, TextChangedEventArgs e) // ивентик когда текст в поле изменяется
        {
            LoginTB.Background = Brushes.White; // изменяем на белый цвет, вдруг если красным было подсвечено
        }

        private void PasswordTB_TextChanged(object sender, TextChangedEventArgs e) // ивентик когда текст в поле изменяется
        {
            PasswordTB.Background = Brushes.White; // изменяем на белый цвет, вдруг если красным было подсвечено
        }

    }
}
