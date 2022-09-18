
using LibaryManagementSystem.Menu;
using System;

namespace LibaryManagementSystem
{
    class Program
    {
        public static void Green(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value.PadRight(Console.WindowWidth));
            // Reset the color.
            Console.ResetColor();
        }

        public static void Red(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value.PadRight(Console.WindowWidth));
            // Reset the color.
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            string username;
            string password;

            IMenu menu = null;
            string getType = "Main";
            do
            {
                Console.WriteLine("Welcome to Libary Management System of University Of Greenwich");
                Console.WriteLine("===> Please! Login");
                Console.Write("===> Username: ");
                username = Console.ReadLine();
                Console.Write("===> Password: ");
                password = Console.ReadLine();

                // Check username and password
                if (username == "admin" && password == "12345")
                {
                    Green("===> Login is successfully. Enter to continue !!!");
                    Console.ReadKey();
                    do
                    {
                        Console.Clear();
                        if (getType == "Main")
                        {
                            menu = new MainMenu();
                        }
                        else if (getType == "Books")
                        {
                            menu = new MenuBooks();
                        }
                        else if (getType == "Readers")
                        {
                            menu = new MenuReaders();
                        }
                        else if (getType == "Categories")
                        {
                            menu = new MenuCategories();
                        }
                        else if (getType == "Publishers")
                        {
                            menu = new MenuPublishers();
                        }
                        else if (getType == "Authors")
                        {
                            menu = new MenuAuthors();
                        }
                        else if (getType == "Issues")
                        {
                            menu = new MenuIssues();
                        }
                        else if (getType == "Invalid")
                        {

                            Red("Invalid choice. Please choose again!\n\n\n");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (getType == "choose")
                        {
                            Red("Choice must be a number. Please enter again!");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        menu.ShowMenu();
                        getType = menu.ChooseMenu();
                    }
                    while (getType != "Close");
                    Red("Alert \"Enter to exit!\"");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Red("Notification: \"Username or Password is incorrect. Please enter agian!!!!!\"");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (username != "admin" || password != "12345");
        }
    }
}
