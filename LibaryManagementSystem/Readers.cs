using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem
{
    class Readers : Person
    {
        public string ReaderID {get;set;}
        public string ReaderName { get; set; }

        //Singleton design pattern
        private static Readers readerIns = null;
        public static Readers GetReadersIns
        {
            get
            {
                readerIns = new Readers();
                return readerIns;
            }
        }
        // Prototype design pattern
        public Readers ReadersClone()
        {
            return (Readers)this.MemberwiseClone();
        }

        // Create a list reader when user open program
        public void Insert2List(List<Readers> readers)
        {
            if (readers.Count == 0)
            {
                Readers readers1 = new Readers();
                readers1.ReaderID = "ID0001";
                readers1.ReaderName = "Minh Tri";
                readers1.DateOfBirth = "28/06/2002";
                readers1.Phone = "09092281658";
                readers1.Email = "abcdef@gmail.com";
                readers.Add(readers1);

                CreateNew(readers, readers1, "ID0002", "Tran Cong Thanh");
                CreateNew(readers, readers1, "ID0003", "Anh Tu");
                CreateNew(readers, readers1, "ID0004", "Ngguyen Minh Hai");
                CreateNew(readers, readers1, "ID0005", "Gia Bao");
            }
        }

        private static void CreateNew(List<Readers> readers, Readers readers1, string id,string name)
        {
            Readers readers2 = new Readers();
            readers2 = readers1.ReadersClone();

            readers2.ReaderID = id;
            readers2.ReaderName = name;
            readers.Add(readers2);
        }

        public void Add(List<Readers> readers)
        {
            AddReaders(readers);
        }
        public void Update(List<Readers> readers)
        {
            UpdateReaders(readers);
        }
        public void Delete(List<Readers> readers)
        {
            DeleteReaders(readers);
        }
        public void View(List<Readers> readers)
        {
            ViewAll(readers);
        }
        public void Search(List<Readers> readers)
        {
            SearchReaders(readers);
        }

        private void ViewAll(List<Readers> readers)
        {
            Console.WriteLine();
            Console.WriteLine("########## LIST OF READERS ##########");
            foreach(Readers reader in readers)
            {
                Console.WriteLine($"Reader ID: {reader.ReaderID} | Reader Name: {reader.ReaderName}" +
                    $" | Date of Birth: {reader.DateOfBirth} | Email: {reader.Email} | Phone: {reader.Phone}");
            }
            Console.WriteLine();
            Green("===> Enter to continute!");
            Console.ReadKey();
        }

        private void AddReaders(List<Readers> readers)
        {
            string flag = "";
            do
            {
                Console.Write("Enter Reader ID: ");
                string readerid = Console.ReadLine();

                Console.Write("Enter Reader Name: ");
                string readername = Console.ReadLine();

                Console.Write("Date of birth: ");
                string dateofbrith = Console.ReadLine();

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter Phone: ");
                string phone = Console.ReadLine();


                Readers objReaders = new Readers();
                objReaders.ReaderID = readerid;
                objReaders.ReaderName = readername;
                objReaders.DateOfBirth = dateofbrith;
                objReaders.Email = email;
                objReaders.Phone = phone;

                readers.Add(objReaders);
                Green("===> Successfully added readers. Enter to continute!");
                Console.ReadKey();
                Green("===> Would you like to add another reader? (y/n)");
                flag = Console.ReadLine();
            }
            while (flag.ToLower().Equals("y"));   
        }

        private void UpdateReaders(List<Readers> readers)
        {
            Console.Write("Enter Reader ID need update: ");
            string id = Console.ReadLine();
            int pos = -1;
            Readers objReaders = new Readers();
            foreach (var reader in readers)
            {
                pos++;
                if (reader.ReaderID == id)
                {
                    objReaders = reader;
                    break;
                }
            }
            string temp = "";

            Console.WriteLine($"Reader Name: {objReaders.ReaderName}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objReaders.ReaderName = temp;
            }

            Console.WriteLine($"Date of Birth: {objReaders.DateOfBirth}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objReaders.DateOfBirth = temp;
            }

            Console.WriteLine($"Email: {objReaders.Email}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objReaders.Email = temp;
            }

            Console.WriteLine($"Phone: {objReaders.Phone}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objReaders.Phone = temp;
            }

            readers[pos] = objReaders;
            Green("===> Successfully updated readers. Enter to continute!");
            Console.ReadKey();
        }

        private void DeleteReaders(List<Readers> readers)
        {
            Console.Write("Enter Reader ID to delete: ");
            string id = Console.ReadLine();

            Readers objReaders = new Readers();
            foreach (var reader in readers)
            {
                if (reader.ReaderID == id)
                {
                    objReaders = reader;
                    break;
                }
            }

            Console.WriteLine($"Reader ID: {objReaders.ReaderID} | Reader Name: {objReaders.ReaderName}" +
                   $" | Date of Birth: {objReaders.DateOfBirth} | Email: {objReaders.Email} | Phone: {objReaders.Phone}");
            Red("Are you sure (y/n)?");
            string flag = Console.ReadLine();
            if (flag.ToLower() == "y")
            {
                readers.Remove(objReaders);
                Green("===> Successfully deteted readers. Enter to continute!");
                Console.ReadKey();
            }
        }

        private void SearchReaders(List<Readers> readers)
        {
            if(readers.Count == 0)
            {
                Red("List Reader is Empty!");
            }
            else
            {
                Console.Write("Enter Reeder ID or Reader Name to find: ");
                string seach = Console.ReadLine();

                foreach (var reader in readers)
                {
                    if (reader.ReaderName == seach || reader.ReaderID == seach)
                    {
                        Green("Result");
                        Console.WriteLine($"Reader ID: {reader.ReaderID} | Reader Name: {reader.ReaderName}" +
                               $" | Date of Birth: {reader.DateOfBirth} | Email: {reader.Email} | Phone: {reader.Phone}");
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

