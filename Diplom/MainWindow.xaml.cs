using Diplom.Droppers;
using Diplom.ViewModels;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public ContentPresenter presenter;

        public static ObservableCollection<UserInfo> usersInfo = new ObservableCollection<UserInfo>();// коллекция пользователей

        public class UserInfo
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Dadname { get; set; }
            public int Role { get; set; }
            public int Progress { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();

            Authorization firstPage = new Authorization();
            firstPage.presenter = MainContent;
            MainContent.Content = firstPage;
            ButtonList.Add(ExitBTN);
            MenuList.Add(TopMenu);

        }

        public static ObservableCollection<Button> ButtonList = new ObservableCollection<Button>(); //коллекция для обращения к нестатичной кнопке
        public static ObservableCollection<Menu> MenuList = new ObservableCollection<Menu>(); 
        public static void ShowExitButton(bool show) //метод для показа/скрытия кнопки выхода
        {
            if (show)
            {
                ButtonList[0].Visibility = Visibility.Visible;
            }
            else
            {
                ButtonList[0].Visibility = Visibility.Hidden;
            }
        }

        private void Logout_BTN(object sender, RoutedEventArgs e) //кнопка выхода
        {
            ExitBTN.Visibility = Visibility.Hidden; //скрываем кнопку после выхода
            Authorization firstPage = new Authorization();
            firstPage.presenter = MainContent;
            MainContent.Content = firstPage;
            MessageBox.Show("Завершение сессии", "Внимание");

        }

        private void OpenTheory_Window(object sender, RoutedEventArgs e)
        {
            new WindowTheory().Show();
        }

        //private void AddNewTest_BTN(object sender, RoutedEventArgs e)
        //{
        //    var menuFinancial = new List<SubItem>();
        //    menuFinancial.Add(new SubItem("XLENO"));
        //    var item1 = new ItemMenu("StreamsO", menuFinancial);

        //    Menu.Children.Add(new UserControlMenuItem(item1, this));

        //}
    }
}
