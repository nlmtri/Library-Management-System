using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem.Menu
{
    class MenuIssues : IMenu
    {
        public static List<Issues> issues = new List<Issues>();
        public new string GetType()
        {
            return "Issues";
        }
        public void ShowMenu()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("              University Of Greenwich             ");
            Console.WriteLine("              Libary Management System            ");
            Console.WriteLine("                  # Menu Issues #                 ");
            Console.WriteLine("              1. Borrow book                      ");
            Console.WriteLine("              2. Return book                      ");
            Console.WriteLine("              3. View All Issuings                ");
            Console.WriteLine("              4. Back to main menu                ");
            Console.WriteLine("              5. Exit                             ");
            Console.WriteLine("**************************************************");
            Issues.GetIssuesIns.Insert2List(issues);
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
                        Issues.GetIssuesIns.Borrow(issues);
                        return "Issues";
                    case 2:
                        Issues.GetIssuesIns.View(issues);
                        Issues.GetIssuesIns.Return(issues);
                        return "Issues";
                    case 3:
                        Issues.GetIssuesIns.View(issues);
                        return "Issues";
                    case 4:
                        return "Main";
                    case 5:
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
