using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.BaseDataRequests;
using FlipBuddy.Persistence.DTO;

namespace FlipBuddy.Persistence.DataRequestObjects.UserRequests
{
	public class GetUserByGuid : GuidDataRequest, IDataFetch<Users_DTO>
	{
		public GetUserByGuid(Guid guid) : base(guid) { }

		public override string GetSql() => $"SELECT * FROM Users WHERE Guid = @Guid";
	}
}
