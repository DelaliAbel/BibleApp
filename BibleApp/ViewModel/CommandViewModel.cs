using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace BibleApp.ViewModel
{
    internal class CommandViewModel
    {
        public string DisplayName { get; set; }
        public string Icon { get; set; }
        public ICommand Command { get; set; }
        public bool IsChecked { get; set; }

        public CommandViewModel()
        {

        }

        public CommandViewModel(string i_displayName, string i_icon, ICommand i_command, bool i_ischecked)
        {
            DisplayName = i_displayName;
            Icon = i_icon;
            Command = i_command;
            IsChecked = i_ischecked;
        }

        public CommandViewModel(string i_displayName, string i_icon, ICommand i_command)
        {
            DisplayName = i_displayName;
            Icon = i_icon;
            Command = i_command;
        }

        public CommandViewModel(string i_icon, ICommand i_command)
        {
            Icon = i_icon;
            Command = i_command;
        }

    }
}
