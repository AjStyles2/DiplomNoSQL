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
    /// Логика взаимодействия для UserControlSet.xaml
    /// </summary>
    public partial class UserControlSet : UserControl
    {

        public static ObservableCollection<TextBox> TextBoxList = new ObservableCollection<TextBox>();

        public UserControlSet()
        {
            InitializeComponent();
            TextBoxList.Add(AnsBox1);
            TextBoxList.Add(AnsBox2);
        }

        public static string[] TestCall()
        {
            string[] koker = { TextBoxList[0].Text, TextBoxList[1].Text };
            return koker;
        }
    }
}
