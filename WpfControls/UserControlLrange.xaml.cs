using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WpfControls
{
    /// <summary>
    /// Логика взаимодействия для UserControlLrange.xaml
    /// </summary>
    public partial class UserControlLrange : UserControl
    {


        public static ObservableCollection<TextBox> TextBoxList = new ObservableCollection<TextBox>();

        public UserControlLrange()
        {
            InitializeComponent();
            TextBoxList.Add(AnsBox1);
            TextBoxList.Add(AnsBox2);
            TextBoxList.Add(AnsBox3);
            TextBoxList.Add(AnsBox4);
            TextBoxList.Add(OutputBox);
        }
    }
}
