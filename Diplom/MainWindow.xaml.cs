using Diplom.Droppers;
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
        public MainWindow()
        {
            InitializeComponent();

            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("SET", new UserControlSet()));
            menuRegister.Add(new SubItem("GET", new UserControlGet()));
            menuRegister.Add(new SubItem("INCR"));
            menuRegister.Add(new SubItem("DECR"));
            var item1 = new ItemMenu("Strings", menuRegister); 

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("RPUSH"));
            menuSchedule.Add(new SubItem("LPUSH"));
            menuSchedule.Add(new SubItem("LRANGE"));
            menuSchedule.Add(new SubItem("RPOP"));
            var item2 = new ItemMenu("Lists", menuSchedule);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("HMSET"));
            menuReports.Add(new SubItem("HGET"));
            menuReports.Add(new SubItem("HGETALL"));
            var item3 = new ItemMenu("Hashes", menuReports);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("PFADD"));
            menuExpenses.Add(new SubItem("PFCOUNT"));
            var item4 = new ItemMenu("HyperLogLogs", menuExpenses);

            var menuFinancial = new List<SubItem>();
            menuFinancial.Add(new SubItem("XLEN"));
            var item5 = new ItemMenu("Streams", menuFinancial);

            Menu.Children.Add(new UserControlMenuItem(item1, this)); // добавляем раскрывающийся пункт к StackPanel
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
            Menu.Children.Add(new UserControlMenuItem(item5, this));
        }

        internal void SwitchScreen(object sender) // метод для смены отображающейся страницы
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }
    }
}
