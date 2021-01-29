using Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository : IRepository
    {
        private readonly string _connectionString;

        public Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("mssqlconnection");
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetCategoryNames", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Category>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToCategory(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetProductsByCategory", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", categoryId));
                    var response = new List<Product>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToProduct(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<IEnumerable<Product>> GetFeaturedProducts()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetFeaturedProducts", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Product>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToProduct(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private Category MapToCategory(SqlDataReader reader)
        {
            return new Category()
            {
                Name = reader["Name"].ToString()
            };
        }

        private Product MapToProduct(SqlDataReader reader)
        {
            return new Product()
            {
                ProductId = new Guid(reader["ProductId"].ToString()),
                Sku = Convert.ToInt32(reader["SKU"].ToString()),
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Category = reader["Category"].ToString(),
                Price = Convert.ToDecimal(reader["Price"].ToString())
            };
        }
    }
}
