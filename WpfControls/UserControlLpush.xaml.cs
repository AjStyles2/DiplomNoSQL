using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WpfControls
{
    /// <summary>
    /// Логика взаимодействия для UserControlLpush.xaml
    /// </summary>
    public partial class UserControlLpush : UserControl
    {

        public static ObservableCollection<TextBox> TextBoxList = new ObservableCollection<TextBox>();
        public UserControlLpush()
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
