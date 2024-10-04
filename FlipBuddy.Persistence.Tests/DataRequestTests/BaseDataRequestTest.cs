using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.Implementation;
using FlipBuddy.Tests.Shared;

namespace FlipBuddy.Persistence.Tests.DataRequestTests
{
	public abstract class BaseDataRequestTest
	{
		protected readonly IDataAccess _dataAccess;

		public BaseDataRequestTest()
		{
			_dataAccess = new DataAccess(new MySqlConnectionFactory(Hidden.DbServer, Hidden.DbPort, Hidden.DbName, Hidden.DbUserId, Hidden.DbPassword));
		}
	}
}
