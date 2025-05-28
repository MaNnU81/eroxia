using eroxia.model;

namespace eroxia
{
    internal interface IStorage
    {
        public Task<List<Product>> GetAllProductsFromDB();
        public Task<List<Employee>> GetAllEmployeesFromDB();
        Task DeleteEmployeeFromDB(string fiscalCode);
        Task DeleteProductFromDB(int productId);
    }
}