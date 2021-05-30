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

namespace WpfControls
{
    /// <summary>
    /// Логика взаимодействия для UserControlIncr.xaml
    /// </summary>
    public partial class UserControlIncr : UserControl
    {
        public static ObservableCollection<TextBox> TextBoxList = new ObservableCollection<TextBox>();
        public UserControlIncr()
        {
            InitializeComponent();
            TextBoxList.Add(AnsBox1);
            TextBoxList.Add(AnsBox2);
            TextBoxList.Add(AnsBox3);
            TextBoxList.Add(AnsBox4);
        }

        public static string[] GetTextBoxes()
        {
            string[] arrayBoxes = { TextBoxList[0].Text, TextBoxList[1].Text, TextBoxList[2].Text, TextBoxList[3].Text };
            return arrayBoxes;
        }
    }
}
