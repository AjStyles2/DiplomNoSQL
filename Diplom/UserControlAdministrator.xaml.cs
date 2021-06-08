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
    /// Логика взаимодействия для UserControlAdministrator.xaml
    /// </summary>
    public partial class UserControlAdministrator : UserControl
    {
        public ContentPresenter presenter;
        public UserControlAdministrator()
        {
            InitializeComponent();
            FindLike("SELECT * FROM Persons");
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
                        fileInfo.Password = Convert.ToString(reader.GetValue(2));
                        fileInfo.Name = Convert.ToString(reader.GetValue(3));
                        fileInfo.Surname = Convert.ToString(reader.GetValue(4));
                        fileInfo.Dadname = Convert.ToString(reader.GetValue(5));
                        fileInfo.Role = Convert.ToInt32(reader.GetValue(6));
                        fileInfo.Progress = Convert.ToInt32(reader.GetValue(7));
                        FileInfoView.ItemsSource = MainWindow.usersInfo;
                        MainWindow.usersInfo.Add(fileInfo);
                    }
                }

                reader.Close();

            }
        }

        private void EditorOpen_Context(object sender, RoutedEventArgs e)
        {
            var userData = MainWindow.usersInfo[FileInfoView.SelectedIndex];
            MessageBox.Show(Convert.ToString(MainWindow.usersInfo[FileInfoView.SelectedIndex].Id));

            var winEdit = new WindowEditor();
            WindowEditor.idUser = userData.Id;
            winEdit.LoginTB.Text = userData.Login;
            winEdit.PasswordTB.Text = userData.Password;
            winEdit.NameTB.Text = userData.Name;
            winEdit.SurnameTB.Text = userData.Surname;
            winEdit.DadnameTB.Text = userData.Dadname;
            winEdit.RightsCB.SelectedIndex = 0;

            winEdit.ShowDialog(); // открытие нового окна
            FindLike("SELECT * FROM Persons"); // обновляем если произошли изменения пользователей
        }

        //private void FindResults()
        //{
        //    string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DiplomUsers;Integrated Security=True";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand();
        //        command.CommandText = "SELECT COUNT(ID_Ex) FROM Results WHERE ID =";
        //        command.Connection = connection;
        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.HasRows) // если есть данные
        //        {
        //            while (reader.Read()) // построчно считываем данные
        //            {
        //                MainWindow.usersInfo
        //                fileInfo.Id = Convert.ToInt32(reader.GetValue(0));
        //                fileInfo.Login = Convert.ToString(reader.GetValue(1));
        //                fileInfo.Password = Convert.ToString(reader.GetValue(2));
        //                fileInfo.Name = Convert.ToString(reader.GetValue(3));
        //                fileInfo.Surname = Convert.ToString(reader.GetValue(4));
        //                fileInfo.Dadname = Convert.ToString(reader.GetValue(5));
        //                fileInfo.Role = Convert.ToInt32(reader.GetValue(6));
        //                fileInfo.Progress = Convert.ToInt32(reader.GetValue(7));
        //                FileInfoView.ItemsSource = MainWindow.usersInfo;
        //                MainWindow.usersInfo.Add(fileInfo);
        //            }
        //        }

        //        reader.Close();

        //    }
        //}


        private void ZeroProgress_Context(object sender, RoutedEventArgs e) // fix on results
        {

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DiplomUsers;Integrated Security=True";

            string sqlExpression = "UPDATE Persons SET Progress=0 WHERE ID=" + MainWindow.usersInfo[FileInfoView.SelectedIndex].Id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                MessageBox.Show("Прогресс пользователя обнулён");
            }
        }

        private void RemoveUser_Context(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DiplomUsers;Integrated Security=True";
            string sqlExpression = "DELETE FROM Persons WHERE ID=" + MainWindow.usersInfo[FileInfoView.SelectedIndex].Id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                if (number == 0)
                {
                    MessageBox.Show("Объект не найден");
                }
                else
                {
                    MessageBox.Show("Удалено объектов: " + number);
                    MainWindow.usersInfo.RemoveAt(FileInfoView.SelectedIndex);
                }
            }
        }
    }
}
