using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem
{
    class MainMenu : IMenu
    {
        string IMenu.GetType()
        {
            return "Main";
        }
        public void ShowMenu()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("              University Of Greenwich             ");
            Console.WriteLine("              Libary Management System            ");
            Console.WriteLine("                  #  Main Menu  #                 ");
            Console.WriteLine("              1. Manage Books                     ");
            Console.WriteLine("              2. Manage Readers                   ");
            Console.WriteLine("              3. Manage Categories                ");
            Console.WriteLine("              4. Manage Publishers                ");
            Console.WriteLine("              5. Manage Authors                   ");
            Console.WriteLine("              6. Manage Issues/Return             ");
            Console.WriteLine("              7. Exit                             ");
            Console.WriteLine("**************************************************");
        }

        public string ChooseMenu()
        {
            Console.Write("Enter your choose: ");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        return "Books";
                    case 2:
                        return "Readers";
                    case 3:
                        return "Categories";
                    case 4:
                        return "Publishers";
                    case 5:
                        return "Authors";
                    case 6:
                        return "Issues";
                    case 7:
                        return "Close";
                    default:
                        return "Invalid";
                }
            }
            catch
            {
                return "choose";
            }
        }
    }
}
