using Diplom.Droppers;
using Diplom.ViewModels;
using System;
using System.Collections.Generic;
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

        public MainWindow()
        {
            InitializeComponent();

            Authorization firstpage = new Authorization();
            firstpage.presenter = MainContent;
            MainContent.Content = firstpage;

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
