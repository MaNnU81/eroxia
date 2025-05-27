using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eroxia.model;

namespace eroxia
{
    internal class BusinessLogic : ILogic
    {
        private IStorage Storage { get; set; }

        private List<Employee> Employees { get; set; } = new List<Employee>();
        private List<Product> Products { get; set; } = new List<Product>();

        public BusinessLogic(IStorage storage)
        {
            Storage = storage;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            if (Employees == null || Employees.Count == 0)
            {
                Employees = await Storage.GetAllEmployeesFromDB();
            }

            foreach (var emp in Employees)
            {
                Console.WriteLine($"Nome: {emp.Name}, Cognome: {emp.Surname}, Codice Fiscale: {emp.FiscalCode}, Data di nascita: {emp.Dob:dd/MM/yyyy}");
            }

            return Employees;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            if (Products == null || Products.Count == 0)
            {
                Products = await Storage.GetAllProductsFromDB();
            }
            foreach (var prod in Products)
            {
                Console.WriteLine($"ID: {prod.ProductId}, Nome: {prod.Name}, Materiale: {prod.Material}, Produttore: {prod.Manufacturer}, Prezzo: {prod.Price:C}, Colore: {prod.Color}");
            }
            return Products;
        }

        public async Task<List<Employee>> DeleteEmployeeAsync()
        {
            if (Employees == null || Employees.Count == 0)
            {
                Employees = await Storage.GetAllEmployeesFromDB();
            }

            Console.Write("Inserisci il codice fiscale dell'impiegato da eliminare: ");
            var fiscalCode = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fiscalCode))
            {
                Console.WriteLine("Codice fiscale non valido.");
                return Employees;
            }

            var employeeToRemove = Employees.FirstOrDefault(e => e.FiscalCode == fiscalCode);

            if (employeeToRemove != null)
            {
                await Storage.DeleteEmployeeFromDB(fiscalCode);
                Employees.Remove(employeeToRemove);
                Console.WriteLine($"Impiegato con codice fiscale {fiscalCode} eliminato dal database e dalla memoria.");
            }
            else
            {
                Console.WriteLine("Impiegato non trovato.");
            }

            return Employees;
        }

        public Task<List<Employee>> InsertEmployeeAsync()
        {
            Console.WriteLine("Funzione non ancora implementata.");
            return Task.FromResult(Employees);
        }

        public async Task<List<Product>> DeleteProductAsync()
        {
            
            if (Products == null || Products.Count == 0)
            {
                Products = await Storage.GetAllProductsFromDB();
            }
           

            Console.Write("Inserisci l'ID del prodotto da eliminare: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int productId))
            {
                Console.WriteLine("ID prodotto non valido.");
                return Products;
            }

            var productToRemove = Products.FirstOrDefault(p => p.ProductId == productId);

            if (productToRemove != null)
            {
                await Storage.DeleteProductFromDB(productId);
                Products.Remove(productToRemove);
                Console.WriteLine($"Prodotto con ID {productId} eliminato dal database e dalla memoria.");
            }
            else
            {
                Console.WriteLine("Prodotto non trovato.");
            }

            return Products;
        }

        public Task<List<Product>> InsertProductAsync()
        {
            Console.WriteLine("Funzione non ancora implementata.");
            return Task.FromResult(Products);
        }
    }
}