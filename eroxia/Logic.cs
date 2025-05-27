using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using eroxia.model;

namespace eroxia
{
    internal interface ILogic
    {
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task<List<Employee>> DeleteEmployeeAsync();
        public Task<List<Employee>> InsertEmployeeAsync();

        public Task<List<Product>> GetAllProductsAsync();
        public Task<List<Product>> DeleteProductAsync();
        public Task<List<Product>> InsertProductAsync();


        




    }
}
