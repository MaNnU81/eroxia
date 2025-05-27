using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eroxia.model;
using Npgsql;

namespace eroxia
{

    internal class DBStorage : IStorage
    {
        public static string postgresConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=Diva;Database=eroxia";  //cambia password in superpippo

        public async Task<List<Product>> GetAllProductsFromDB()
        {
            var dataSourceBuilder = new Npgsql.NpgsqlDataSourceBuilder(postgresConnectionString);
            var dataSource = dataSourceBuilder.Build();
            var conn = await dataSource.OpenConnectionAsync();

            using var query = new Npgsql.NpgsqlCommand("SELECT id_product, name, manufacturer, price, material, color FROM product", conn);

            using var reader = query.ExecuteReader();

            var products = new List<Product>();
            while (reader.Read())
            {
                var product = new Product(
                    reader.GetInt32(0), // ProductId
                    reader.GetString(1), // Name
                    reader.GetString(2), // Manufacturer
                    reader.GetDecimal(3) // Price
                )
                {
                    Material = reader.IsDBNull(4) ? null : reader.GetString(4), // Material
                    Color = reader.IsDBNull(5) ? null : reader.GetString(5) // Color
                };
                products.Add(product);
            }

            return products;

        }

        public async Task<List<Employee>> GetAllEmployeesFromDB()
        {
            var dataSourceBuilder = new Npgsql.NpgsqlDataSourceBuilder(postgresConnectionString);
            var dataSource = dataSourceBuilder.Build();
            var conn = await dataSource.OpenConnectionAsync();

            using var query = new Npgsql.NpgsqlCommand("SELECT dob, fiscal_code, name, surname FROM employee", conn);

            using var reader = query.ExecuteReader();

            var employees = new List<Employee>();
            while (reader.Read())
            {
                var employee = new Employee(
                    reader.GetDateTime(0),    // Dob
                    reader.GetString(1),      // FiscalCode
                    reader.GetString(2),      // Name
                    reader.GetString(3)       // Surname
                );
                employees.Add(employee);
            }

            return employees;
        }

        public async Task DeleteEmployeeFromDB(string fiscalCode)
        {
            var dataSourceBuilder = new Npgsql.NpgsqlDataSourceBuilder(postgresConnectionString);
            var dataSource = dataSourceBuilder.Build();
            await using var conn = await dataSource.OpenConnectionAsync();

            using var cmd = new Npgsql.NpgsqlCommand("DELETE FROM employee WHERE fiscal_code = @fiscalCode", conn);
            cmd.Parameters.AddWithValue("@fiscalCode", fiscalCode);

            await cmd.ExecuteNonQueryAsync();
        }
    

        public async Task DeleteProductFromDB(int productId)
        {
            var dataSourceBuilder = new Npgsql.NpgsqlDataSourceBuilder(postgresConnectionString);
            var dataSource = dataSourceBuilder.Build();
            await using var conn = await dataSource.OpenConnectionAsync();

            using var cmd = new Npgsql.NpgsqlCommand("DELETE FROM product WHERE id_product = @productId", conn);
            cmd.Parameters.AddWithValue("@productId", productId);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
