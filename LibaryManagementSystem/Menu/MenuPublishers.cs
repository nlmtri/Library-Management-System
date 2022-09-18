using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem
{
    class MenuPublishers:IMenu
    {
        public static List<Publishers> publishers = new List<Publishers>();
        public new string GetType()
        {
            return "Publishers";
        }
        public void ShowMenu()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("              University Of Greenwich             ");
            Console.WriteLine("              Libary Management System            ");
            Console.WriteLine("                  # Menu Publishers #             ");
            Console.WriteLine("              1. Add Publishers                   ");
            Console.WriteLine("              2. Delete Publishers                ");
            Console.WriteLine("              3. Update Publishers                ");
            Console.WriteLine("              4. View All Publishers              ");
            Console.WriteLine("              5. Search Publishers                ");
            Console.WriteLine("              6. Back to main menu                ");
            Console.WriteLine("              7. Exit                             ");
            Console.WriteLine("**************************************************");
            Publishers.GetPublishersIns.Insert2List(publishers);
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
                        Publishers.GetPublishersIns.Add(publishers);
                        return "Publishers";
                    case 2:
                        Publishers.GetPublishersIns.View(publishers);
                        Publishers.GetPublishersIns.Delete(publishers);
                        return "Publishers";
                    case 3:
                        Publishers.GetPublishersIns.View(publishers);
                        Publishers.GetPublishersIns.Update(publishers);
                        return "Publishers";
                    case 4:
                        Publishers.GetPublishersIns.View(publishers);
                        return "Publishers";
                    case 5:
                        Publishers.GetPublishersIns.Search(publishers);
                        return "Publishers";
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
