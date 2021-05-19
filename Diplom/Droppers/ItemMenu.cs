using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls; // подключаем контролы

namespace Diplom.Droppers
{
    public class ItemMenu
    {
        public ItemMenu(string header, List<SubItem> subItems) 
        {
            Header = header;
            SubItems = subItems;
        }

        public string Header { get; private set; }
        public List<SubItem> SubItems { get; private set; }
        public UserControl Screen { get; private set; }
    }
}
