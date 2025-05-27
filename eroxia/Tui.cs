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

        public void Start() {

            Console.WriteLine("Welcome to Eroxia Management System");
            Console.WriteLine("1. View all employees");
            Console.WriteLine("2. View all products");
            Console.WriteLine("3. Exit");
            while (true)
            {
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
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}
