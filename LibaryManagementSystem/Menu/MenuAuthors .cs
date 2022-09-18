using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem
{
    class MenuAuthors:IMenu
    {
        public static List<Authors> authors = new List<Authors>();

        public new string GetType()
        {
            return "Authors";
        }
        public void ShowMenu()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("              University Of Greenwich             ");
            Console.WriteLine("              Libary Management System            ");
            Console.WriteLine("                  # Menu Authors #                ");
            Console.WriteLine("              1. Add Authors                      ");
            Console.WriteLine("              2. Delete Authors                   ");
            Console.WriteLine("              3. Update Authors                   ");
            Console.WriteLine("              4. View All Authors                 ");
            Console.WriteLine("              5. Search Authors                   ");
            Console.WriteLine("              6. Back to main menu                ");
            Console.WriteLine("              7. Exit                             ");
            Console.WriteLine("**************************************************");
            Authors.GetAuthorsIns.Insert2List(authors);
        }
        // Get choose of user and return menu
        public string ChooseMenu()
        {
            Console.Write("Enter your choose: ");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Authors.GetAuthorsIns.Add(authors);
                        return "Authors";
                    case 2:
                        Authors.GetAuthorsIns.View(authors);
                        Authors.GetAuthorsIns.Delete(authors);
                        return "Authors";
                    case 3:
                        Authors.GetAuthorsIns.View(authors);
                        Authors.GetAuthorsIns.Update(authors);
                        return "Authors";
                    case 4:
                        Authors.GetAuthorsIns.View(authors);
                        return "Authors";
                    case 5:
                        Authors.GetAuthorsIns.Search(authors);
                        return "Authors";
                    case 6:
                        return "Main";
                    case 7:
                        return "Close";
                    default:
                        return "Main";
                }
            }
            catch
            {
                return "choose";
            }
        }
    }
}
