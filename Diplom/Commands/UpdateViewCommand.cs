using Diplom.ViewModels; // подключаем папку ViewModels
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Diplom.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            //ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect("localhost"); // соединение с редис

            //IDatabase db = muxer.GetDatabase();

            var redis = RedisStore.RedisCache;

            if (parameter.ToString() == "Getter")
            {
                //viewModel.SelectedViewModel = new TestViewModel();
                
                string[] arrayTextBoxes = UserControlGet.TestCall();
                
                if (arrayTextBoxes[0].ToLower().Equals("get")) // проверяем запрос без учёта регистра пользователя
                {
                    if (arrayTextBoxes[1].Equals("TestKey"))
                    {
                        string value = redis.StringGet(arrayTextBoxes[1]);
                        MessageBox.Show(value, arrayTextBoxes[0]);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка в названии ключа", "ОШИБКА");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка в написании запроса GET", "ОШИБКА");
                }

            }
            else if (parameter.ToString() == "Requester")
            {

                string[] arrayTextBoxes = UserControlSet.TestCall();

                if (arrayTextBoxes[0].ToLower().Equals("set")) // проверяем запрос без учёта регистра пользователя
                {

                    redis.StringSet("TestKey", arrayTextBoxes[1]);
                    MessageBox.Show("Успешно добавлено", "ВНИМАНИЕ");
                    
                }
                else
                {
                    MessageBox.Show("Ошибка в написании запроса SET", "ОШИБКА");
                }

            }
            else if (parameter.ToString() == "Setter")
            {

            }
            else if (parameter.ToString() == "Incr")
            {

                string[] arrayTextBoxes = WpfControls.UserControlIncr.GetTextBoxes();

                if (arrayTextBoxes[0].ToLower().Equals("set")) // проверяем запрос без учёта регистра пользователя
                {
                    int num;
                    bool isNum = int.TryParse(arrayTextBoxes[1], out num );
                    
                    if (isNum)
                    {
                        redis.StringSet("IncrKey", num);
                        //MessageBox.Show("Успешно добавлено", "ВНИМАНИЕ");
                        if (arrayTextBoxes[2].ToLower().Equals("incr"))
                        {
                            if (arrayTextBoxes[3].Equals("IncrKey"))
                            {
                                redis.StringIncrement("IncrKey");
                                MessageBox.Show("Успешно добавлено", "ВНИМАНИЕ");
                            }
                            else
                            {
                                MessageBox.Show("Указан неверный ключ", "ВНИМАНИЕ");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Нужно указать запрос INCR", "ОШИБКА");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Значение не должно содержать других символов", "ОШИБКА");
                    }

                }
                else
                {
                    MessageBox.Show("Ошибка в написании запроса SET", "ОШИБКА");
                }

            }
            else if (parameter.ToString() == "Decr")
            {

                string[] arrayTextBoxes = WpfControls.UserControlDecr.GetTextBoxes();

                if (arrayTextBoxes[0].ToLower().Equals("set")) // проверяем запрос без учёта регистра пользователя
                {
                    int num;
                    bool isNum = int.TryParse(arrayTextBoxes[1], out num);

                    if (isNum)
                    {
                        redis.StringSet("DecrKey", num);
                        //MessageBox.Show("Успешно добавлено", "ВНИМАНИЕ");
                        if (arrayTextBoxes[2].ToLower().Equals("decr"))
                        {
                            if (arrayTextBoxes[3].Equals("DecrKey"))
                            {
                                redis.StringIncrement("DecrKey");
                                MessageBox.Show("Успешно добавлено", "ВНИМАНИЕ");
                            }
                            else
                            {
                                MessageBox.Show("Указан неверный ключ", "ВНИМАНИЕ");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Нужно указать запрос DECR", "ОШИБКА");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Значение не должно содержать других символов", "ОШИБКА");
                    }

                }
                else
                {
                    MessageBox.Show("Ошибка в написании запроса SET", "ОШИБКА");
                }

            }




            //else if (parameter.ToString() == "Account")
            //{
            //    viewModel.SelectedViewModel = new AccountViewModel();
            //}
        }

        //private void UpdateNumBtn()
        //{


        //    int idtypetostr = typeBox.SelectedIndex + 1; // с нуля + 1, т.к в бдхе с 1 тип начинается

        //    string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DiplomUsers;Integrated Security=True";

        //    string sqlExpression = "UPDATE [Exercises] SET Phone=" + txnumchange.Text + ", Id_Type=" + idtypetostr + " WHERE Id=" + phoneOwnInfo[Convert.ToInt32(FileNumEdView.SelectedIndex)].Id;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(sqlExpression, connection);
        //        int number = command.ExecuteNonQuery();
        //        MessageBox.Show("Обновлено объектов:" + number);
        //    }
        //}

    }
}
