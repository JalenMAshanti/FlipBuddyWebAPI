using FlipBuddy.Persistence.Abstractions;
using Dapper;
using MySql.Data.MySqlClient;
using FlipBuddy.Domain.Exceptions;

namespace FlipBuddy.Persistence.Implementation
{
    public class DataAccess : IDataAccess
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DataAccess(IDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;

        public async Task<int> ExecuteAsync(IDataExecute request)
        {
            try
            {
                using var connection = _connectionFactory.NewConnection();

                connection.Open();

                var rowsAffected = await connection.ExecuteAsync(request.GetSql(), request.GetParameters());

                connection.Close();

                return rowsAffected;

            }
            catch (MySqlException ex)
            {
                throw new DataAccessException(ex.Message, ex.Number, ex);
            }
        }

        public async Task<TResponse?> FetchAsync<TResponse>(IDataFetch<TResponse> request)
        {
            try
            {
                using var connection = _connectionFactory.NewConnection();

                connection.Open();

                var rowsaffected = await connection.QueryFirstOrDefaultAsync<TResponse>(request.GetSql(), request.GetParameters());

                connection.Close();
                
                return rowsaffected;

            }
			catch (MySqlException ex)
			{
				throw new DataAccessException(ex.Message, ex.Number, ex);
			}
		}

        public  async Task<IEnumerable<TResponse>> FetchListAsync<TResponse>(IDataFetch<TResponse> request)
        {
            try
            {
                using var connection = _connectionFactory.NewConnection();

                connection.Open();

                var rowsaffected = await connection.QueryAsync<TResponse>(request.GetSql(), request.GetParameters());

                connection.Close();

                return rowsaffected;
            }
			catch (MySqlException ex)
			{
				throw new DataAccessException(ex.Message, ex.Number, ex);
			}
		}
    }
}
