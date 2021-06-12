using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WpfControls
{
    /// <summary>
    /// Логика взаимодействия для UserControlHmset.xaml
    /// </summary>
    public partial class UserControlHmset : UserControl
    {
        public static ObservableCollection<TextBox> TextBoxList = new ObservableCollection<TextBox>();
        public UserControlHmset()
        {
            InitializeComponent();
            TextBoxList.Add(AnsBox1); //hmset
            TextBoxList.Add(AnsBox2); // arg1
            TextBoxList.Add(AnsBox3); // arg2
            TextBoxList.Add(OutputBox);
        }
    }
}
