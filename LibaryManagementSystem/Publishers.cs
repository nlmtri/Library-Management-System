using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem
{
    class Publishers
    {
        public static List<Books> books = new List<Books>();

        public string PublisherID { get; set; }
        public string PublisherName { get; set; }
        
        //Singleton design pattern
        private static Publishers publishersIns = null;
        public static Publishers GetPublishersIns
        {
            get
            {
                publishersIns = new Publishers();
                return publishersIns;
            }
        }

        //Prototype design pattern
        public Publishers PublishersClone()
        {
            return (Publishers)this.MemberwiseClone();
        }

        // Create a list publisher when user open program
        public void Insert2List(List<Publishers> publishers)
        {
            if (publishers.Count == 0)
            {
                Publishers publishers1 = new Publishers();
                publishers1.PublisherID = "PB0001";
                publishers1.PublisherName = "Tuoi Tre";
                publishers.Add(publishers1);

                CreateNew(publishers, publishers1, "PB0002", "Giao Duc");
                CreateNew(publishers, publishers1, "PB0003", "Khoa Hoc");
            }
        }

        private static void CreateNew(List<Publishers> publishers, Publishers publishers1, string id, string name)
        {
            Publishers publishers2 = new Publishers();
            publishers2 = publishers1.PublishersClone();

            publishers2.PublisherID = id;
            publishers2.PublisherName = name;
            publishers.Add(publishers2);
        }

        // Facade design pattern
        public void Add(List<Publishers> publishers)
        {
            AddPublishers(publishers);
        }

        public void Delete(List<Publishers> publishers)
        {
            DeletePublishers(publishers);
        }

        public void Update(List<Publishers> publishers)
        {
            UpdatePublishers(publishers);
        }

        public void View(List<Publishers> publishers)
        {
            ViewAll(publishers);
        }

        public void Search(List<Publishers> publishers)
        {
            SearchPublishers(publishers);
        }

        private void ViewAll(List<Publishers> publishers)
        {
            Console.WriteLine();
            Console.WriteLine("########## LIST OF PUBLISHERS ##########");
            foreach (Publishers publisher in publishers)
            {
                Console.WriteLine($"Publisher ID: {publisher.PublisherID} | Publisher Name: {publisher.PublisherName}");
            }
            Console.WriteLine();
            Green("===> Enter to continute!");
            Console.ReadKey();
        }

        private void AddPublishers(List<Publishers> publishers)
        {
            string flag="";
            do
            {
                Console.Write("Enter Publisher ID: ");
                string publisherid = Console.ReadLine();

                Console.Write("Enter Publisher Name: ");
                string publishername = Console.ReadLine();


                Publishers objPublisher = new Publishers();
                objPublisher.PublisherID = publisherid;
                objPublisher.PublisherName = publishername;

                publishers.Add(objPublisher);
                Green("===> Successfully added publishers. Enter to continute!");
                Console.ReadKey();
                Green("===> Would you like to add another publisher? (y/n)");
                flag = Console.ReadLine();
            }
            while (flag.ToLower().Equals("y"));
        }

        private void UpdatePublishers(List<Publishers> publishers)
        {
            Console.Write("Enter Publisher ID need update: ");
            string id = Console.ReadLine();
            int pos = -1;
            Publishers objPublishers = new Publishers();
            foreach (var publisher in publishers)
            {
                pos++;
                if (publisher.PublisherID == id)
                {
                    objPublishers = publisher;
                    break;
                }
            }
            string temp = "";

            Console.WriteLine($"Publishers Name: {objPublishers.PublisherName}");
            Console.Write("==> ");
            temp = Console.ReadLine();
            if (temp != "")
            {
                objPublishers.PublisherName = temp;
            }

            publishers[pos] = objPublishers;
            Green("===> Successfully updated publishers. Enter to continute!");
            Console.ReadKey();
        }

        private void DeletePublishers(List<Publishers> publishers)
        {
            Console.Write("Enter Publisher ID to delete: ");
            string id = Console.ReadLine();

            Publishers objPublishers = new Publishers();
            foreach (var publisher in publishers)
            {
                if (publisher.PublisherName == id)
                {
                    objPublishers = publisher;
                    break;
                }
            }

            Console.WriteLine($"Publisher ID: {objPublishers.PublisherID} | Publisher Name: {objPublishers.PublisherName}");
            Red("Are you sure (y/n)?");
            string flag = Console.ReadLine();
            if (flag.ToLower() == "y")
            {
                publishers.Remove(objPublishers);
                Green("===> Successfully deteted publishers. Enter to continute!");
                Console.ReadKey();
            }
        }

        private void SearchPublishers(List<Publishers> publishers)
        {
            if (publishers.Count == 0)
            {
                Red("List Publisher is Empty!");
            }
            else
            {
                Console.Write("Enter Publisher ID or Publisher Name to find: ");
                string seach = Console.ReadLine();

                foreach (var publisher in publishers)
                {
                    if (publisher.PublisherID == seach || publisher.PublisherName == seach)
                    {
                        Green("Result");
                        Console.WriteLine($"Publisher ID: {publisher.PublisherID} | Publisher Name: {publisher.PublisherName}");
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
