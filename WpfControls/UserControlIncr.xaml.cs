using System.Collections.ObjectModel;
using System.Windows.Controls;

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
            TextBoxList.Add(OutputBox);
        }

        public static string[] GetTextBoxes()
        {
            string[] arrayBoxes = { TextBoxList[0].Text, TextBoxList[1].Text, TextBoxList[2].Text, TextBoxList[3].Text };
            return arrayBoxes;
        }
    }
}
