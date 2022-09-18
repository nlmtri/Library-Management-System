using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem
{
    class Authors:Person
    {
        public static List<Books> books = new List<Books>();

        public string AuthorID { get; set; }
        public string AuthorName { get; set; }

        //Singleton design pattern
        private static Authors authorsIns = null;
        public static Authors GetAuthorsIns
        {
            get
            {
                authorsIns = new Authors();
                return authorsIns;
            }
        }

        //Prototype design pattern
        public Authors AuthorsClone()
        {
            return (Authors)this.MemberwiseClone();
        }
        // Create a list author when user open program
        public void Insert2List(List<Authors> authors)
        {
            if (authors.Count == 0)
            {
                Authors authors1 = new Authors();
                authors1.AuthorID = "AU0001";
                authors1.AuthorName = "Dale Carnegie";
                authors1.DateOfBirth = "01/01/2001";
                authors1.Phone = "0123456789";
                authors1.Email = "abcdef@gmail.com";
                authors.Add(authors1);

                CreateNew(authors, authors1, "AU0002", "Jonh Harry");
                CreateNew(authors, authors1, "AU0003", "Petter Jonhson");
            }
        }

        private static void CreateNew(List<Authors> authors, Authors authors1, string id, string name)
        {
            Authors authors2 = new Authors();
            authors2 = authors1.AuthorsClone();

            authors2.AuthorID = id;
            authors2.AuthorName = name;
            authors.Add(authors2);
        }

        // Facade design pattern
        public void Add(List<Authors> authors)
        {
            AddAuthors(authors);
        }
        public void Delete(List<Authors> authors)
        {
            DeleteAuthors(authors);
        }
        public void Update(List<Authors> authors)
        {
            UpdateAuthors(authors);
        }
        public void View(List<Authors> authors)
        {
            ViewAll(authors);
        }
        public void Search(List<Authors> authors)
        {
            SearchAuthros(authors);
        }

        private void ViewAll(List<Authors> authors)
        {
            Console.WriteLine();
            Console.WriteLine("########## LIST OF AUTHORS ##########");
            foreach (Authors author in authors)
            {
                Console.WriteLine($"Author ID: {author.AuthorID} | Author Name: {author.AuthorName}" +
                    $" | Date of Birth: {author.DateOfBirth} | Email: {author.Email} | Phone: {author.Phone}");
            }
            Console.WriteLine();
            Green("===> Enter to continute!");
            Console.ReadKey();
        }

        private void AddAuthors(List<Authors> authors)
        {
            string flag = "";
            do
            {
                Console.Write("Enter Author ID: ");
                string authorid = Console.ReadLine();

                Console.Write("Enter Author Name: ");
                string authorname = Console.ReadLine();

                Console.Write("Date of birth: ");
                string dateofbrith = Console.ReadLine();

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter Phone: ");
                string phone = Console.ReadLine();

                Authors objAuthors = new Authors();
                objAuthors.AuthorID = authorid;
                objAuthors.AuthorName = authorname;
                objAuthors.DateOfBirth = dateofbrith;
                objAuthors.Email = email;
                objAuthors.Phone = phone;

                authors.Add(objAuthors);
                Console.WriteLine();
                Green("===> Successfully added authors. Enter to continute!");
                Console.ReadKey();
                Green("===> Would you like to add another author? (y/n)");
                flag = Console.ReadLine();
            }
            while (flag.ToLower().Equals("y"));
        }

        private void UpdateAuthors(List<Authors> authors)
        {
            Console.Write("Enter Author ID need update: ");
            string id = Console.ReadLine();
            int pos = -1;
            Authors objAuthors = new Authors();
            foreach (var author in authors)
            {
                pos++;
                if (author.AuthorID == id)
                {
                    objAuthors = author;
                    break;
                }
            }
            string temp = "";

            Console.WriteLine($"Author Name: {objAuthors.AuthorName}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objAuthors.AuthorName = temp;
            }

            Console.WriteLine($"Date of Birth: {objAuthors.DateOfBirth}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objAuthors.DateOfBirth = temp;
            }

            Console.WriteLine($"Email: {objAuthors.Email}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objAuthors.Email = temp;
            }

            Console.WriteLine($"Phone: {objAuthors.Phone}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objAuthors.Phone = temp;
            }

            authors[pos] = objAuthors;
            Green("===> Successfully updated authors. Enter to continute!");
            Console.ReadKey();
        }

        private void DeleteAuthors(List<Authors> authors)
        {
            Console.Write("Enter Author ID to delete: ");
            string id = Console.ReadLine();

            Authors objAthours = new Authors();
            foreach (var author in authors)
            {
                if (author.AuthorID == id)
                {
                    objAthours = author;
                    break;
                }
            }

            Console.WriteLine($"Author ID: {objAthours.AuthorID} | Author Name: {objAthours.AuthorName}" +
                   $" | Date of Birth: {objAthours.DateOfBirth} | Email: {objAthours.Email} | Phone: {objAthours.Phone}");
            Red("Are you sure (y/n)?");
            string flag = Console.ReadLine();
            if (flag.ToLower() == "y")
            {
                authors.Remove(objAthours);
                Green("===> Successfully deteted authors. Enter to continute!");
                Console.ReadKey();
            }
        }
        

        private void SearchAuthros(List<Authors> authors)
        {
            if (authors.Count == 0)
            {
                Red("List Author is Empty!");
            }
            else
            {
                Console.Write("Enter Author ID or Author Name to find: ");
                string seach = Console.ReadLine();

                foreach (var author in authors)
                {
                    if (author.AuthorID == seach || author.AuthorName == seach)
                    {
                        Green("Result");
                        Console.WriteLine($"Reader ID: {author.AuthorID} | Reader Name: {author.AuthorName}" +
                               $" | Date of Birth: {author.DateOfBirth} | Email: {author.Email} | Phone: {author.Phone}");
                        Console.ReadLine();
                    }
                }
            }
        }
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
    }
}
