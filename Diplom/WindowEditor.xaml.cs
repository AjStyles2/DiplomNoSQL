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
using System.Windows.Shapes;

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для WindowEditor.xaml
    /// </summary>
    public partial class WindowEditor : Window
    {
        public static int idUser = 0;
        public WindowEditor()
        {
            InitializeComponent();
        }

        private void Accept_Btn(object sender, RoutedEventArgs e)
        {

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DiplomUsers;Integrated Security=True";

            string sqlExpression = "UPDATE Persons SET Login='" + LoginTB.Text + "', Password='" + PasswordTB.Text + "', Name='" + NameTB.Text + "', Surname='" + SurnameTB.Text + "', Dadname='" + DadnameTB.Text + "', Role='" + RightsCB.Text + "' WHERE ID=" + idUser;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                MessageBox.Show("Обновлено объектов:" + number);
            }
        }

        private void Cancel_Btn(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
