using Diplom.ViewModels; // подключаем папку ViewModels
using StackExchange.Redis;
using System;
using System.Collections.Generic;
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

            ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect("localhost"); // соединение с редис

            IDatabase db = muxer.GetDatabase();

            if (parameter.ToString() == "Home")
            {
                //viewModel.SelectedViewModel = new TestViewModel();
                
                string[] arrayTextBoxes = UserControlGet.TestCall();
                
                if (arrayTextBoxes[0].ToLower().Equals("get")) // проверяем запрос без учёта регистра пользователя
                {
                    if (arrayTextBoxes[1].Equals("TestKey"))
                    {
                        string value = db.StringGet(arrayTextBoxes[1]);
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
            else if (parameter.ToString() == "Setter")
            {

                string[] arrayTextBoxes = UserControlSet.TestCall();

                if (arrayTextBoxes[0].ToLower().Equals("set")) // проверяем запрос без учёта регистра пользователя
                {

                    db.StringSet("TestKey", arrayTextBoxes[1]);
                    MessageBox.Show("Успешно добавлено", "ВНИМАНИЕ");
                    
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

    }
}
