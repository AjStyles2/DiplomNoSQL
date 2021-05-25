using Diplom.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для UserControlGet.xaml
    /// </summary>
    public partial class UserControlGet : UserControl
    {

        public static ObservableCollection<TextBox> TextBoxList = new ObservableCollection<TextBox>();
        public UserControlGet()
        {
            InitializeComponent();
            TextBoxList.Add(AnsBox1);
            TextBoxList.Add(AnsBox2);
        }

        private void CheckAnswer_BTN(object sender, RoutedEventArgs e)
        {
            //if(AnsBox1.Text.ToLower() == "get") // проверка текстбокса 
            //{
            //    GridResult.Background = new SolidColorBrush(Color.FromArgb(100, 25, 200, 25)); // цвет фона
            //    ResultLbl.Content = "ВЕРНО";
            //    ResultLbl.Foreground = new SolidColorBrush(Color.FromArgb(200, 50, 225, 50)); // цвет текста
            //    ResultLbl.Visibility = Visibility.Visible; // показываем текст результата
            //}
            //else
            //{               
            //    GridResult.Background = new SolidColorBrush(Color.FromArgb(100, 200, 25, 25));
            //    ResultLbl.Content = "НЕВЕРНО";
            //    ResultLbl.Foreground = new SolidColorBrush(Color.FromArgb(200, 225, 50, 50));
            //    ResultLbl.Visibility = Visibility.Visible;
            //}
            
            //DescriptionLbl.Visibility = Visibility.Hidden;
            //AnsBox1.Visibility = Visibility.Hidden;
            //AnsBtn.Visibility = Visibility.Hidden;

        }

            
        private void MouseClickGrid_HOOK(object sender, MouseButtonEventArgs e)
        {
            //if (Convert.ToString(GridResult.Background) == "#64C81919") // проверка на красный цвет фона, чтобы юзер был оповещён об ошибке и повторил тестик
            //{
            //    DescriptionLbl.Visibility = Visibility.Visible;
            //    AnsBox1.Visibility = Visibility.Visible;
            //    AnsBtn.Visibility = Visibility.Visible;
            //    GridResult.Background = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255)); // возвращаем белый
            //    ResultLbl.Visibility = Visibility.Hidden;
            //}
            //else
            //{
            //    //MainWindow.SwitchScreen(new UserControlSet());
            //    //var screen = new UserControlSet();

            //    //if (screen != null)
            //    //{
            //    //    MainWindow.StackPanelMain.Children.Clear();
            //    //    MainWindow.StackPanelMain.Children.Add(screen);
            //    //}
            //}

        }

        public static string[] TestCall()
        {
            string[] koker = { TextBoxList[0].Text, TextBoxList[1].Text };
            return koker;
        }
    }
}
