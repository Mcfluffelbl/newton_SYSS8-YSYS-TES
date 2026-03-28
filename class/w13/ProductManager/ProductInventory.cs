using System;
using Npgsql;
using System.Collections.Generic;

namespace ProductManager
{
    public class ProductInventory
    {
        private readonly string _connectionString;

        public ProductInventory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> GetProductsByCategory(string category)
        {
            var products = new List<Product>();

            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var cmd = new NpgsqlCommand(
                "SELECT name, category, price FROM products WHERE category = @category",
                conn
            );

            cmd.Parameters.AddWithValue("category", category);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    Name = reader.GetString(0),
                    Category = reader.GetString(1),
                    Price = reader.GetString(2)
                });
            }

            return products;
        }
    }
}