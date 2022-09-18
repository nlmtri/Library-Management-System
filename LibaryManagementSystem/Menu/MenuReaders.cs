using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem.Menu
{
    class MenuReaders: IMenu
    {
        public static List<Readers> readers = new List<Readers>();
        public new string GetType()
        {
            return "Readers";
        }
        public void ShowMenu()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("              University Of Greenwich             ");
            Console.WriteLine("              Libary Management System            ");
            Console.WriteLine("                  # Menu Readers #                ");
            Console.WriteLine("              1. Add Readers                      ");
            Console.WriteLine("              2. Delete Readers                   ");
            Console.WriteLine("              3. Update Readers                   ");
            Console.WriteLine("              4. View All Readers                 ");
            Console.WriteLine("              5. Search Readers                   ");
            Console.WriteLine("              6. Back to main menu                ");
            Console.WriteLine("              7. Exit                             ");
            Console.WriteLine("**************************************************");
            Readers.GetReadersIns.Insert2List(readers);
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
                        Readers.GetReadersIns.Add(readers);
                        return "Readers";
                    case 2:
                        Readers.GetReadersIns.View(readers);
                        Readers.GetReadersIns.Delete(readers);
                        return "Readers";
                    case 3:
                        Readers.GetReadersIns.View(readers);
                        Readers.GetReadersIns.Update(readers);
                        return "Readers";
                    case 4:
                        Readers.GetReadersIns.View(readers);
                        return "Readers";
                    case 5:
                        Readers.GetReadersIns.Search(readers);
                        return "Readers";
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
 