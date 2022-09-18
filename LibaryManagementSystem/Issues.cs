using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryManagementSystem
{
    class Issues
    {
        public string IssueID { get; set; }
        public string BookID { get; set; }
        public string ReaderID { get; set; }


        //Singleton design pattern
        private static Issues issueIns = null;
        public static Issues GetIssuesIns
        {
            get
            {
                issueIns = new Issues();
                return issueIns;
            }
        }
        // Prototype design pattern
        public Issues IssuesClone()
        {
            return (Issues)this.MemberwiseClone();
        }

        // Create a list reader when user open program
        public void Insert2List(List<Issues> issues)
        {
            if (issues.Count == 0)
            {
                Issues issues1 = new Issues();
                issues1.IssueID = "IS0001";
                issues1.BookID = "LB0001";
                issues1.ReaderID = "ID0001";
                issues.Add(issues1);

                CreateNew(issues, issues1, "IS0002", "LB0002", "ID0002");
                CreateNew(issues, issues1, "IS0003", "LB0003", "ID0003");
                CreateNew(issues, issues1, "IS0004", "LB0004", "ID0004");
            }
        }

        private static void CreateNew(List<Issues> issues, Issues issues1, string id, string bid, string rid)
        {
            Issues issues2 = new Issues();
            issues2 = issues1.IssuesClone();

            issues2.IssueID = id;
            issues2.BookID = bid;
            issues2.ReaderID = rid;
            issues.Add(issues2);
        }

        public void Borrow(List<Issues> issues)
        {
            BorrowBook(issues);
        }

        public void Return(List<Issues> issues)
        {
            ReturnBook(issues);
        }
        public void View(List<Issues> issues)
        {
            ViewAll(issues);
        }


        private void ViewAll(List<Issues> issues)
        {
            Console.WriteLine();
            Console.WriteLine("########## LIST OF READERS ##########");
            foreach (Issues issue in issues)
            {
                Console.WriteLine($"Issue ID: {issue.IssueID} | Book ID: {issue.BookID}" +
                    $" | Reader ID: {issue.ReaderID}");
            }
            Console.WriteLine();
            Green("===> Enter to continute!");
            Console.ReadKey();
        }

        private void BorrowBook(List<Issues> issues)
        {
            string flag = "";
            do
            {
                Console.Write("Enter Issue ID: ");
                string issueid = Console.ReadLine();

                Console.Write("Enter Book ID: ");
                string bookid = Console.ReadLine();

                Console.Write("Enter Reader ID: ");
                string readerid = Console.ReadLine();


                Issues objIssues = new Issues();
                objIssues.IssueID = issueid;
                objIssues.BookID = bookid;
                objIssues.ReaderID = readerid;

                issues.Add(objIssues);
                Green("===> Successfully added issues. Enter to continute!");
                Console.ReadKey();
                Green("===> Would you like to add another reader? (y/n)");
                flag = Console.ReadLine();
            }
            while (flag.ToLower().Equals("y"));
        }


        private void ReturnBook(List<Issues> issues)
        {
            Console.Write("Enter Issue ID to return: ");
            string id = Console.ReadLine();

            Issues objIssues = new Issues();
            foreach (var reader in issues)
            {
                if (reader.IssueID == id)
                {
                    objIssues = reader;
                    break;
                }
            }

            Console.WriteLine($"Issue ID: {objIssues.IssueID} | Book ID: {objIssues.BookID}" +
                    $" | Reader ID: {objIssues.ReaderID}");
            Red("Are you sure (y/n)?");
            string flag = Console.ReadLine();
            if (flag.ToLower() == "y")
            {
                issues.Remove(objIssues);
                Green("===> Successfully deteted issues. Enter to continute!");
                Console.ReadKey();
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

