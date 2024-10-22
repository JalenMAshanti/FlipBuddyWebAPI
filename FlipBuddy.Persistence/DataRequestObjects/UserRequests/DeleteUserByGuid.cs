using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.BaseDataRequests;

namespace FlipBuddy.Persistence.DataRequestObjects.UserRequests
{
	public class DeleteUserByGuid : GuidDataRequest, IDataExecute
	{
		public DeleteUserByGuid(Guid guid) : base(guid) { }
		public override string GetSql() => $@"DELETE FROM {DatabaseTable.Users} WHERE Guid = @Guid";
	}
}
