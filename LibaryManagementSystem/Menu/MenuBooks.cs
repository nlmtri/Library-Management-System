using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem
{
    class MenuBooks : IMenu
    {
        public static List<Books> books = new List<Books>();

        public new string GetType()
        {
            return "Books";
        }
        public void ShowMenu()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("              University Of Greenwich             ");
            Console.WriteLine("              Libary Management System            ");
            Console.WriteLine("                  # Menu Books #                  ");
            Console.WriteLine("              1. Add Books                        ");
            Console.WriteLine("              2. Delete Books                     ");
            Console.WriteLine("              3. Update Books                     ");
            Console.WriteLine("              4. View All Books                   ");
            Console.WriteLine("              5. Search Books                     ");
            Console.WriteLine("              6. Back to main menu                ");
            Console.WriteLine("              7. Exit                             ");
            Console.WriteLine("**************************************************");
            Books.GetBooksIns.Insert2List(books);
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
                        Books.GetBooksIns.Add(books);
                        return "Books";
                    case 2:
                        Books.GetBooksIns.View(books);
                        Books.GetBooksIns.Delete(books);
                        return "Books";
                    case 3:
                        Books.GetBooksIns.View(books);
                        Books.GetBooksIns.Update(books);
                        return "Books";
                    case 4:
                        Books.GetBooksIns.View(books);
                        return "Books";
                    case 5:
                        Books.GetBooksIns.Search(books);
                        return "Books";
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
