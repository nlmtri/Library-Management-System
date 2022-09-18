using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem
{
    interface IMenu
    {
        public string GetType();
        public void ShowMenu();
        public string ChooseMenu();
    }
}
