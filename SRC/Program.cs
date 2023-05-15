using System;
using System.IO;
using StoreManagement;
using StoreManagement.Classes;

namespace StoreManagement
{
    public class Class
    {
        DatabaseAddItem addItem;
        DatabaseDeliver deliverDone;
        DatabaseShow show;
        DatabaseSendDelivery deliver;
        static DatabaseCheckConnection checker;
        public static string pass;

        public static void Main()
        {

            Header();
            Password();
            checker = new DatabaseCheckConnection(pass, null);
            while (true)
            {
                Console.Clear();
                Header();
                var instance = new Class();
                instance.Menu();
            }
        }

        public static void Header()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t----------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t  Store Admin Pannel");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t----------------------\n\n");
            Console.ResetColor();
        }

        public static void Password()
        {
            Console.Write("Please enter the password to access the Database : ");
            pass = Console.ReadLine() ?? "N/A";
        }

        public void Menu()
        {
            Console.WriteLine("Choose your option : ");
            Console.WriteLine("1 - Add an Item\t\t2 - Add a New Delivery");
            Console.WriteLine("3 - Finish a Delivery\t4 - Show an Item\n\n");
            Console.Write("Your choice : ");
            switch(int.TryParse(Console.ReadLine(), out int output) ? output : 0)
            {
                case 1:
                    Console.Clear();
                    Header();
                    Console.Write("Enter the name of the new item : ");
                    addItem = new DatabaseAddItem(pass, null, Console.ReadLine() ?? "Unknown");
                    break;
                case 2:
                    Console.Clear();
                    Header();
                    Console.Write("Enter the name of the item you want to add delivery for : ");
                    string name = Console.ReadLine();
                    Console.Write("Enter the amount of items you're delivering : ");
                    deliver = new DatabaseSendDelivery(pass, null, name, int.TryParse(Console.ReadLine(), out output) ? output : 0);
                    break;
                case 3:
                    Console.Clear();
                    Header();
                    Console.Write("Enter the name of the item you want to finish delivery for : ");
                    name = Console.ReadLine();
                    Console.Write("Enter the amount of items that are done delivering : ");
                    deliverDone = new DatabaseDeliver(pass, null, name, int.TryParse(Console.ReadLine(), out output) ? output : 0);
                    break;
                case 4:
                    Console.Clear();
                    Header();
                    Console.Write("Enter the name of the item you want to show : ");
                    show = new DatabaseShow(pass, null, Console.ReadLine() ?? "Unknown");
                    Console.WriteLine("\nPress ENTER to continue");
                    Console.ReadKey();
                    break;
            }
        }
    }
}