using Dapper;
using NorthwindWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NorthwindWeb.Data
{
    public class NorthwindRepository
    {
        private readonly string _connectionString;

        public NorthwindRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;
        }

        public IEnumerable<Customer> GetCustomersByCountry(string country, int pageNumber = 1, int pageSize = 10)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Customer>(
                    "sp_GetCustomersByCountry",
                    new { Country = country, PageNumber = pageNumber, PageSize = pageSize },
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }

        public IEnumerable<Order> GetOrdersByCustomerId(string customerId, int pageNumber = 1, int pageSize = 10)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Order>(
                    "sp_GetOrdersByCustomerId",
                    new { CustomerID = customerId, PageNumber = pageNumber, PageSize = pageSize },
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }

        public void InsertWebTracker(string urlRequest, string sourceIp)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(
                    "sp_InsertWebTracker",
                    new { URLRequest = urlRequest, SourceIp = sourceIp },
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}