using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eroxia
{
    internal class Tui
    {
        
        private ILogic Logic { get; set; }  
        public Tui(ILogic logic) 
        {
            Logic = logic;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Eroxia Management System");

            while (true)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. View all employees");
                Console.WriteLine("2. View all products");
                Console.WriteLine("3. Insert value");
                Console.WriteLine("4. Delete value");
                Console.WriteLine("5. Exit");

                Console.Write("Please select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Logic.GetAllEmployeesAsync();
                        break;
                    case "2":
                        Logic.GetAllProductsAsync();
                        break;
                    case "3":
                        ShowInsertMenu();
                        break;
                    case "4":
                        ShowDeleteMenu();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private void ShowInsertMenu()
        {
            while (true)
            {
                Console.WriteLine("\nInsert Menu:");
                Console.WriteLine("1. Insert product");
                Console.WriteLine("2. Insert employee");
                Console.WriteLine("3. Back to main menu");

                Console.Write("Please select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Logic.InsertProductAsync();
                        break;
                    case "2":
                        Logic.InsertEmployeeAsync();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private void ShowDeleteMenu()
        {
            while (true)
            {
                Console.WriteLine("\nDelete Menu:");
                Console.WriteLine("1. Delete product");
                Console.WriteLine("2. Delete employee");
                Console.WriteLine("3. Back to main menu");

                Console.Write("Please select an option: ");
                var input = Console.ReadLine();
               

                switch (input)
                {
                    case "1":
                        Logic.DeleteProductAsync();
                        break;
                    case "2":
                        Logic.DeleteEmployeeAsync();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}
