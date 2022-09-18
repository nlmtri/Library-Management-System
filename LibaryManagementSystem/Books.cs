using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem
{
    class Books
    {
        public static List<Publishers> publishers = new List<Publishers>();
        public static List<Authors> authors = new List<Authors>();
        public static List<Categories> categories = new List<Categories>();

        public static void Red(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value.PadRight(Console.WindowWidth));
            // Reset the color.
            Console.ResetColor();
        }

        public string BookID { get; set; }
        public string BookName { get; set; }
        public string YearPublished { get; set; }
        public string Edition { get; set; }
        public int Price { get; set; }
        public string CategoryID { get; set; }
        public string AuthorID { get; set; }
        public string PublisherID { get; set; }

        //Singleton design pattern
        private static Books booksIns = null;
        public static Books GetBooksIns
        {
            get
            {
                booksIns = new Books();
                return booksIns;
            }
        }

        // Prototype design pattern
        public Books BooksClone()
        {
            return (Books)this.MemberwiseClone();
        }
        // Create a list book when user open program
        public void Insert2List(List<Books> books)
        {
            if (books.Count == 0)
            {
                Books books1 = new Books();
                books1.BookID = "LB0001";
                books1.BookName = "Dac Nhan Tam";
                books1.YearPublished = "1936";
                books1.Edition = "2";
                books1.Price = 50;
                books1.CategoryID = "CT0001";
                books1.AuthorID = "AU0001";
                books1.PublisherID = "PB0001";
                books.Add(books1);

                CreateNew(books, books1, "LB0002", "Tuoi Tre Dang Gia Bao Nhieu", "2010");
                CreateNew(books, books1, "LB0003", "Hay Song Cuoc Doi Nhu Ban Muon", "2008");
            }
        }

        private static void CreateNew(List<Books> books, Books books1, string id, string name, string year)
        {
            Books books2 = new Books();
            books2 = books1.BooksClone();
            books2.BookID = id;
            books2.BookName = name;
            books2.YearPublished = year;
            books.Add(books2);
        }
        // Facade design pattern
        public void Add(List<Books> books)
        {
            AddBooks(books);
        }

        public void Update(List<Books> books)
        {
            UpdateBooks(books);
        }

        public void Delete(List<Books> books)
        {
            DeleteBooks(books);
        }

        public void View(List<Books> books)
        {
            ViewAll(books);
        }

        public void Search(List<Books> books)
        {
            SearchBooks(books);
        }

        private void AddBooks(List<Books> books)
        {
            Categories.GetCategoryIns.Insert2List(categories);
            Authors.GetAuthorsIns.Insert2List(authors);
            Publishers.GetPublishersIns.Insert2List(publishers);

            string flag = "";
            do
            {
                // Enter Books Information
                Console.Write("Enter Book ID: ");
                string bookid = Console.ReadLine();

                Console.Write("Enter Book Name: ");
                string bookname = Console.ReadLine();

                Console.Write("Enter Year Published: ");
                string yearpublished = Console.ReadLine();

                Console.Write("Enter Edition: ");
                string edition = Console.ReadLine();
                Console.Write("Enter Price: ");
                int price = Int32.Parse(Console.ReadLine());

                Categories.GetCategoryIns.View(categories);
                Console.Write("Enter Category ID: ");
                string categoryid = Console.ReadLine();

                Authors.GetAuthorsIns.View(authors);
                Console.Write("Enter Author ID: ");
                string authorid = Console.ReadLine();

                Publishers.GetPublishersIns.View(publishers);
                Console.Write("Enter Publisher ID: ");
                string publisherid = Console.ReadLine();

                Books objBooks = new Books();
                objBooks.BookID = bookid;
                objBooks.BookName = bookname;
                objBooks.YearPublished = yearpublished;
                objBooks.Edition = edition;
                objBooks.Price = price;
                objBooks.CategoryID = categoryid;
                objBooks.AuthorID = authorid;
                objBooks.PublisherID = publisherid;

                books.Add(objBooks);
                Green("===> Successfully added books. Enter to continute!");
                Console.ReadKey();
                Green("===> Would you like to add another book? (y/n)");
                flag = Console.ReadLine();
            }
            while (flag.ToLower().Equals("y"));
        }

        private void ViewAll(List<Books> books)
        {
            Console.WriteLine();
            Console.WriteLine("########## LIST OF BOOKS ##########");
            foreach (Books book in books)
            {
                Console.WriteLine($"Book ID: {book.BookID} | Book Name: {book.BookName}" +
                    $" | Year Published: {book.YearPublished} | Edition: {book.Edition}" +
                    $" | Price: {book.Price} | Category ID: {book.CategoryID} | " +
                    $"Author ID: {book.AuthorID} | Publisher ID: {book.PublisherID}");
            }
            Console.WriteLine();
            Green("===> Enter to continute!");
            Console.ReadKey();
        }

        private void UpdateBooks(List<Books> books)
        {
            Console.Write("Enter Book ID need update: ");
            string id = Console.ReadLine();
            int pos = -1;
            Books objBooks = new Books();
            foreach (var book in books)
            {
                pos++;
                if (book.BookID == id)
                {
                    objBooks = book;
                    break;
                }
            }
            string temp = "";
            Console.WriteLine($"Book Name: {objBooks.BookName}");
            Console.Write("==>");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objBooks.BookName = temp;
            }

            Console.WriteLine($"Year Published: {objBooks.YearPublished}");
            Console.Write("==>");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objBooks.YearPublished = temp;
            }

            Console.WriteLine($"Edition: {objBooks.Edition}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objBooks.Edition = temp;
            }

            Console.WriteLine($"Price: {objBooks.Price}");
            Console.Write("==> ");
            int price = Int32.Parse(Console.ReadLine());
            if (temp != "")
            {
                objBooks.Price = price;
            }

            Console.WriteLine($"Category ID: {objBooks.CategoryID}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objBooks.CategoryID = temp;
            }

            Console.WriteLine($"AuthorID ID: {objBooks.AuthorID}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objBooks.AuthorID = temp;
            }

            Console.WriteLine($"Publisher ID: {objBooks.PublisherID}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objBooks.PublisherID = temp;
            }
            books[pos] = objBooks;
            Green("===> Successfully updated books. Enter to continute!");
            Console.ReadKey();
        }

        private void DeleteBooks(List<Books> books)
        {
            Console.Write("Enter Book ID to delete: ");
            string id = Console.ReadLine();

            Books objBooks = new Books();
            foreach (var book in books)
            {
                if (book.BookID == id)
                {
                    objBooks = book;
                    break;
                }
            }
            Console.WriteLine($"Book ID: {objBooks.BookID} | Book Name: {objBooks.BookName}" +
                $" | Year Published: {objBooks.YearPublished} | Edition: {objBooks.Edition}" +
                $" | Price: {objBooks.Price} | Category ID: {objBooks.CategoryID} | " +
                $"Author ID: {objBooks.AuthorID} | Publisher ID: {objBooks.PublisherID}");
            Red("Are you sure (y/n)?");
            string flag = Console.ReadLine();
            if (flag.ToLower() == "y")
            {
                books.Remove(objBooks);
                Green("===> Successfully deteted books. Enter to continute!");
                Console.ReadKey();
            }
        }

        private void SearchBooks(List<Books> books)
        {
            if (books.Count == 0)
            {
                Red("List Book is Empty!");
            }
            else
            {
                Console.Write("Enter Book ID or Book Name to find: ");
                string search = Console.ReadLine();

                foreach (var book in books)
                {
                    if (book.BookID == search | book.BookName == search)
                    {
                        Green("Result");
                        Console.WriteLine($"Book ID: {book.BookID} | Book Name: {book.BookName}" +
                            $" | Year Published: {book.YearPublished} | Edition: {book.Edition}" +
                            $" | Price: {book.Price} | Category ID: {book.CategoryID} | " +
                            $"Author ID: {book.AuthorID} | Publisher ID: {book.PublisherID}");
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
    }
}
