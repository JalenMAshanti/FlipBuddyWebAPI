using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.Implementation;

namespace FlipBuddy.Tests.Shared.Helpers
{
	public class TestDataAccess
	{
		public static readonly IDataAccess SharedInstance;
		static TestDataAccess()
		{
			SharedInstance = new DataAccess(new MySqlConnectionFactory(Hidden.DbServer, Hidden.DbPort, Hidden.DbName, Hidden.DbUserId, Hidden.DbPassword));
		}		
	}
}
