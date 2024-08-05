using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Library
{/// <summary>
/// Shiffy Kupferstein
/// DB Project
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Connect library = new Connect();
            library.OpenConn();
            //Members draw/return books
            Console.WriteLine("Draw and retrun books:\n");
            char members = 'y';
            while (members == 'y')
            {
                //Get member info

                BookDraw a = new BookDraw();
                Console.Write("Member ID:");
                try//check if member entered invalid id
                {
                    int memberID = int.Parse(Console.ReadLine());
                    int drawedbooks = a.BooksDrawed(memberID);
                    int checkmemberid = a.NumBooksEligable(memberID);
                    if (checkmemberid != -1)//check if member id exists in db
                    {

                        Console.WriteLine(drawedbooks);
                        Console.WriteLine();

                        //check if needs to return books
                        if (drawedbooks == 0) Console.WriteLine("Member has no books to return.");
                        else
                        {
                            Console.WriteLine("Member has " + drawedbooks + " books to return:\n");
                            library.PrintTable("select * from BookDraws where MemberID = " + memberID + " and Status = 'drawed'");//Prints info of books to return
                            Console.WriteLine();
                            char returnBook;
                            Console.Write("Return books? (y/n)");
                            bool tryChar0 = char.TryParse(Console.ReadLine(), out returnBook);
                            while (!tryChar0)
                            {
                                Console.WriteLine("Reply should be y/n.\nTry again.");
                                Console.Write("Return books? (y/n)");
                                tryChar0 = char.TryParse(Console.ReadLine(), out returnBook);
                            }

                            while (returnBook != 'y' && returnBook != 'n')//in case entered a different char - not y /n
                            {
                                Console.WriteLine("Reply should be y/n.\nTry again.");
                                Console.Write("Return books?  (y/n)");
                                bool tryChar3 = char.TryParse(Console.ReadLine(), out returnBook);
                                while (!tryChar3)
                                {
                                    Console.WriteLine("Reply should be y/n.\nTry again.");
                                    Console.Write("Return books? (y/n)");
                                    tryChar3 = char.TryParse(Console.ReadLine(), out returnBook);
                                }
                            }
                            if (returnBook == 'y')//if member chose to return books then proceed
                            {
                                //return book

                                char again = 'y';

                                while (again == 'y')
                                {
                                    Console.Write("Return book (book id): ");
                                    try
                                    {
                                        int bookID = int.Parse(Console.ReadLine());
                                        a.ReturnBook(memberID, bookID);
                                        drawedbooks = a.BooksDrawed(memberID);
                                        if (drawedbooks > 0)
                                        {
                                            Console.Write("Return another book? (y/n)");
                                            bool tryChar4 = char.TryParse(Console.ReadLine(), out again);
                                            while (!tryChar4)
                                            {
                                                Console.WriteLine("Reply should be y/n.\nTry again.");
                                                Console.Write("Return another book? (y/n)");
                                                tryChar4 = char.TryParse(Console.ReadLine(), out again);
                                            }
                                            while (again != 'y' && again != 'n')
                                            {
                                                Console.WriteLine("Reply should be y/n.\nTry again.");
                                                Console.Write("Return another book? (y/n)");
                                                again = char.Parse(Console.ReadLine());
                                            }

                                        }
                                        else again = 'n';
                                    }
                                    catch(FormatException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }

                                };

                            }


                        }
                        Console.WriteLine();

                        //check if able to draw books
                        int booksleft = a.NumBooksEligable(memberID);
                        if (booksleft == 0) Console.WriteLine("member is currently not eligable to draw books.");
                        else
                        {
                            Console.WriteLine("Member is currently eligable to draw " + booksleft + " books.");
                            Console.Write("Draw books? (y/n)");
                            char draw;
                            bool tryChar1 = char.TryParse(Console.ReadLine(), out draw);
                            while (!tryChar1)
                            {
                                Console.WriteLine("Reply should be y/n.\nTry again.");
                                Console.Write("Draw books? (y/n)");
                                tryChar1 = char.TryParse(Console.ReadLine(), out draw);
                            }
                            while (draw != 'y' && draw != 'n')
                            {
                                Console.WriteLine("Reply should be y/n.\nTry again.");
                                Console.Write("Draw books? (y/n)");
                                draw = char.Parse(Console.ReadLine());
                            }
                            if (draw == 'y')
                            {
                                //Draw book


                                char again = 'y';

                                while (again == 'y')
                                {
                                    Console.Write("Draw book (book id): ");
                                    try
                                    {
                                        int bookID = int.Parse(Console.ReadLine());
                                        a.DrawBook(memberID, bookID);
                                        booksleft = a.NumBooksEligable(memberID);
                                        if (booksleft > 0)
                                        {
                                            Console.Write("Draw another book? (y/n)");
                                            tryChar1 = char.TryParse(Console.ReadLine(), out again);
                                            while (!tryChar1)
                                            {
                                                Console.WriteLine("Reply should be y/n.\nTry again.");
                                                Console.Write("Draw another book? (y/n)");
                                                tryChar1 = char.TryParse(Console.ReadLine(), out again);
                                            }
                                            while (again != 'y' && again != 'n')
                                            {
                                                Console.WriteLine("Reply should be y/n.\nTry again.");
                                                Console.Write("Draw another book? (y/n)");
                                                again = char.Parse(Console.ReadLine());
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have drawed the maximum books you are aligable for.");
                                            again = 'n';
                                        }
                                    }
                                    catch(FormatException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                };


                            }
                        }

                        Console.Write("Enter another member? (y/n)");
                        bool tryChar8 = char.TryParse(Console.ReadLine(), out members);
                        while (!tryChar8)
                        {
                            Console.WriteLine("Reply should be y/n.\nTry again.");
                            Console.Write("Enter another member? (y/n)");
                            tryChar8 = char.TryParse(Console.ReadLine(), out members);
                        }
                        while (members != 'y' && members != 'n')
                        {
                            Console.WriteLine("Reply should be y/n.\nTry again.");
                            Console.Write("Enter another member? (y/n)");
                            members = char.Parse(Console.ReadLine());
                        }
                    }

                    else
                    {
                        Console.WriteLine("Member ID does not exist.");
                    }
                    }
                
                catch (FormatException error)
                {
                    Console.WriteLine(error.Message);
                }
            }

            
            //Create orders:
            Console.WriteLine("Creating orders:\n");
            Console.WriteLine();
            char order = 'y';
            Console.Write("Create new order? (y/n)");
            bool tryChar = char.TryParse(Console.ReadLine(), out order);
            while (!tryChar)
            {
                Console.WriteLine("Reply should be y/n.\nTry again.");
                Console.Write("Create new order? (y/n)");
                tryChar = char.TryParse(Console.ReadLine(), out order);
            }
            while (order != 'y' && order != 'n')
            {
                Console.WriteLine("Reply should be y/n.\nTry again.");
                Console.Write("Create new order? (y/n)");
                order = char.Parse(Console.ReadLine());
            }
            while (order == 'y')
            {
                Console.Write("Enter supplier ID: (choose from list)");
                library.PrintTable("select SupplierID from Suppliers");
                try
                {
                    int supplier = int.Parse(Console.ReadLine());
                    Orders o = new Orders();
                    int orderID = o.NewOrder(supplier);
                    if (orderID != -1)
                    {
                        Console.WriteLine("Add books to order:");
                        char enterBooks = 'y';
                        while (enterBooks == 'y')
                        {
                            try
                            {
                                Console.Write("Book name: ");
                                string bookName = Console.ReadLine();
                                Console.Write("Author name: ");
                                string author = Console.ReadLine(); ;
                                Console.Write("Quantity: ");
                                int quantity = int.Parse(Console.ReadLine());
                                Console.Write("Price: ");
                                decimal price = decimal.Parse(Console.ReadLine());                            
                                o.AddBookToOrder(orderID, bookName, author, price, quantity);

                            }
                            catch(FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }

                            Console.Write("Add another book to order? (y/n)");
                            bool tryChar5 = char.TryParse(Console.ReadLine(), out enterBooks);
                            while (!tryChar5)
                            {
                                Console.WriteLine("Reply should be y/n.\nTry again.");
                                Console.Write("Add another book to order? (y/n)");
                                tryChar5 = char.TryParse(Console.ReadLine(), out enterBooks);
                            }
                            while (enterBooks != 'y' && enterBooks != 'n')
                            {
                                Console.WriteLine("Reply should be y/n.\nTry again.");
                                Console.Write("Add another book to order? (y/n)");
                                order = char.Parse(Console.ReadLine());
                            }
                        }
                        Console.Write("Order total: ");
                        library.PrintTable("select Sum(BookPrice * quantity) as Total from OrderDetails where OrderID = " + orderID + " group by OrderID");
                        Console.WriteLine();
                        Console.Write("Create another order? (y/n)");
                        bool tryChar6 = char.TryParse(Console.ReadLine(), out order);
                        while (!tryChar6)
                        {
                            Console.WriteLine("Reply should be y/n.\nTry again.");
                            Console.Write("Create another order? (y/n)");
                            tryChar6 = char.TryParse(Console.ReadLine(), out order);
                        }
                        while (order != 'y' && order != 'n')
                        {
                            Console.WriteLine("Reply should be y/n.\nTry again.");
                            Console.Write("Create another order? (y/n)");
                            order = char.Parse(Console.ReadLine());
                        }
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            library.Closeconn();
            Console.ReadKey();
        }
        
    }
}
