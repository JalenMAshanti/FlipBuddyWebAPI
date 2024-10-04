using System.Data;

namespace FlipBuddy.Persistence.Abstractions
{
    public interface IDbConnectionFactory
    {
        public IDbConnection NewConnection();
    }
}
