using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.BaseDataRequests;

namespace FlipBuddy.Persistence.DataRequestObjects.ProductRequests
{
	public class DeleteProductByGuid : GuidDataRequest, IDataExecute
	{
		public DeleteProductByGuid(Guid guid) : base(guid){ }
		public override string GetSql() => $@"DELETE FROM {DatabaseTable.Products} WHERE Guid = @Guid";		
	}
}
