

using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Microsoft.Data.SqlClient;          
using Microsoft.Extensions.Configuration; 



namespace ECommerceInfraStructureLair
{

        public interface IDbConnectionFactory
        {
             Task<DbConnection> OpenAsync(CancellationToken ct = default);
        }
         


        public sealed class SqlConnectionFactory : IDbConnectionFactory
        {
            
             private readonly string _connectionString;
         

             public SqlConnectionFactory(string connectionString)
             => _connectionString = connectionString; 


             public async Task<DbConnection> OpenAsync(CancellationToken ct = default)
             {
                 var connection = new SqlConnection(_connectionString);  // SQL Server(_connectionString);
                 await connection.OpenAsync(ct);
                 return connection;
             }


             
        }








}