using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WpfControls
{
    /// <summary>
    /// Логика взаимодействия для UserControlRpush.xaml
    /// </summary>
    public partial class UserControlRpush : UserControl
    {
        public static ObservableCollection<TextBox> TextBoxList = new ObservableCollection<TextBox>();
        public UserControlRpush()
        {
            InitializeComponent();

            TextBoxList.Add(AnsBox1);
            TextBoxList.Add(AnsBox2);
            TextBoxList.Add(AnsBox3);
            TextBoxList.Add(AnsBox4);
            TextBoxList.Add(AnsBox5);
            TextBoxList.Add(AnsBox6);
            TextBoxList.Add(AnsBox7);
            TextBoxList.Add(OutputBox);
        }
    }
}
