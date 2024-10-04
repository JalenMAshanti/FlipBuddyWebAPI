using FlipBuddy.Persistence.Abstractions;
using MySql.Data.MySqlClient;
using System.Data;

namespace FlipBuddy.Persistence.Implementation
{
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

		public MySqlConnectionFactory (string connectionstring) => _connectionString = connectionstring;

        public MySqlConnectionFactory(string server, uint port, string databaseName, string userId, string password)
        {
            var builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Database = "flipbuddydb", 
                UserID = "root", 
                Password = "password", 
                Port = 3306,
                Pooling = false
            };

            _connectionString = builder.ConnectionString;
        }

        public IDbConnection NewConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
