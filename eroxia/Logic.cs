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
        public  Task<List<Employee>> GetAllEmployeesAsync();
        public Task<List<Product>> GetAllProductsAsync();
        

      
    }
}
