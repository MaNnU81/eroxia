using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eroxia.model;

namespace eroxia
{
    internal class BusinessLogic : ILogic
    {

        private IStorage Storage { get; set; }

        private List<Employee> Employees { get; set; } 
        private List<Product> Products { get; set; }

        public BusinessLogic(IStorage storage)
        {
            Storage = storage;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            if (Employees == null)
            {
                // Recupera gli impiegati dal database
                Employees = await Storage.GetAllEmployeesFromDB();
            }

            // Stampa su console
            foreach (var emp in Employees)
            {
                Console.WriteLine($"Nome: {emp.Name}, Cognome: {emp.Surname}, Codice Fiscale: {emp.FiscalCode}, Data di nascita: {emp.Dob:dd/MM/yyyy}");
            }

            return Employees;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {

            if (Products == null)
            {
                Products = await Storage.GetAllProductsFromDB();
            }
            foreach (var prod in Products)
            {
                Console.WriteLine($"ID: {prod.ProductId}, Nome: {prod.Name}, Materiale: {prod.Material}, Produttore: {prod.Manufacturer}, Prezzo: {prod.Price:C}, Colore: {prod.Color}");
            }
            return Products;
        }

        
    }
}
