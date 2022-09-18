using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem
{
    class MenuCategories: IMenu
    {
        public static List<Categories> categories = new List<Categories>();
        public new string GetType()
        {
            return "Categories";
        }
        public void ShowMenu()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("              University Of Greenwich             ");
            Console.WriteLine("              Libary Management System            ");
            Console.WriteLine("                  # Menu Categories #             ");
            Console.WriteLine("              1. Add Categories                   ");
            Console.WriteLine("              2. Delete Categories                ");
            Console.WriteLine("              3. Update Categories                ");
            Console.WriteLine("              4. View All Categories              ");
            Console.WriteLine("              5. Search Categories                ");
            Console.WriteLine("              6. Back to main menu                ");
            Console.WriteLine("              7. Exit                             ");
            Console.WriteLine("**************************************************");
            Categories.GetCategoryIns.Insert2List(categories);
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
                        Categories.GetCategoryIns.Add(categories);
                        return "Categories";
                    case 2:
                        Categories.GetCategoryIns.View(categories);
                        Categories.GetCategoryIns.Delete(categories);
                        return "Categories";
                    case 3:
                        Categories.GetCategoryIns.View(categories);
                        Categories.GetCategoryIns.Update(categories);
                        return "Categories";
                    case 4:
                        Categories.GetCategoryIns.View(categories);
                        return "Categories";
                    case 5:
                        Categories.GetCategoryIns.Search(categories);
                        return "Categories";
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
