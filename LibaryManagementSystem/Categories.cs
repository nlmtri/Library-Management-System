using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem
{
    class Categories
    {
        public static List<Books> books = new List<Books>();

        public string CategoryID { get; set; }
        public string CategoryName { get; set; }

        //Singleton design pattern
        private static Categories categoryIns = null;
        public static Categories GetCategoryIns
        {
            get
            {
                categoryIns = new Categories();
                return categoryIns;
            }
        }

        //Prototype
        public Categories CategoriesClone()
        {
            return (Categories)this.MemberwiseClone();
        }

        // Create a list category when user open program
        public void Insert2List(List<Categories> categories)
        {
            if (categories.Count == 0)
            {
                Categories categories1 = new Categories();
                categories1.CategoryID = "CT0001";
                categories1.CategoryName = "Self-Help";
                categories.Add(categories1);

                CreateNew(categories, categories1, "CT0002", "Technology");
                CreateNew(categories, categories1, "CT0003", "Science");
            }
        }

        private static void CreateNew(List<Categories> categories, Categories categories1, string id, string name)
        {
            Categories categories2 = new Categories();
            categories2 = categories1.CategoriesClone();

            categories2.CategoryID = id;
            categories2.CategoryName = name;
            categories.Add(categories2);
        }
        // Facade design pattern
        public void Add(List<Categories> categories)
        {
            AddCategories(categories);
        }

        public void Delete(List<Categories> categories)
        {
            DeleteCategories(categories);
        }

        public void Update(List<Categories> categories)
        {
            UpdateCategories(categories);
        }

        public void View(List<Categories> categories)
        {
            ViewAll(categories);
        }

        public void Search(List<Categories> categories)
        {
            SearchCategories(categories);
        }

        private void ViewAll(List<Categories> categories)
        {
            Console.WriteLine();
            Console.WriteLine("########## LIST OF CATEGORIES ##########");
            foreach (Categories category in categories)
            {
                Console.WriteLine($"Category ID: {category.CategoryID} | Category Name: {category.CategoryName}");
            }
            Console.WriteLine();
            Green("===> Enter to continute!");
            Console.ReadKey();
        }

        private void AddCategories(List<Categories> categories)
        {
            string flag = "";
            do
            {
                Console.Write("Enter Category ID: ");
                string categoryid = Console.ReadLine();

                Console.Write("Enter Category Name: ");
                string categoryname = Console.ReadLine();

                Categories objCategories = new Categories();
                objCategories.CategoryID = categoryid;
                objCategories.CategoryName = categoryname;

                categories.Add(objCategories);
                Console.WriteLine();
                Green("===> Successfully added categories. Enter to continute!");
                Console.ReadKey();
                Green("==> Would you like to add another category? (y/n)");
                flag = Console.ReadLine();
            }
            while (flag.ToLower().Equals("y"));
        }
        private void UpdateCategories(List<Categories> categories)
        {
            Console.Write("Enter Category ID need update: ");
            string id = Console.ReadLine();
            int pos = -1;
            Categories objCategories = new Categories();
            foreach (var category in categories)
            {
                pos++;
                if (category.CategoryID == id)
                {
                    objCategories = category;
                    break;
                }
            }
            string temp = "";

            Console.WriteLine($"Category Name: {objCategories.CategoryName}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objCategories.CategoryName = temp;
            }

            categories[pos] = objCategories;
            Green("===> Successfully updated cateroies. Enter to continute!");
            Console.ReadKey();
        }

        private void DeleteCategories(List<Categories> categories)
        {
            Console.Write("Enter Category ID to delete: ");
            string id = Console.ReadLine();

            Categories objCategories = new Categories();
            foreach (var category in categories)
            {
                if (category.CategoryID == id)
                {
                    objCategories = category;
                    break;
                }
            }
            Console.WriteLine($"Category ID: {objCategories.CategoryID} | Category Name: {objCategories.CategoryName}");
            Red("Are you sure (y/n)?");
            string flag = Console.ReadLine();
            if (flag.ToLower() == "y")
            {
                categories.Remove(objCategories);
                Green("===> Successfully deteted categories. Enter to continute!");
                Console.ReadKey();
            }
        }

        private void SearchCategories(List<Categories> categories)
        {
            if (categories.Count == 0)
            {
                Red("List Category is Empty!");
            }
            else
            {
                Console.Write("Enter Category ID or Category Name to find: ");
                string seach = Console.ReadLine();

                foreach (var category in categories)
                {
                    if (category.CategoryID == seach || category.CategoryName == seach)
                    {
                        Green("Result");
                        Console.WriteLine($"Category ID: {category.CategoryID} | Category Name: {category.CategoryName}");
                        Console.ReadLine();
                    }
                }
            }
        }
        public static void Green(string value)
        {
            // Color line
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
    }
}
