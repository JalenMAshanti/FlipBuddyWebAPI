using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests
{
	public class DeleteProductSpecific : IDataExecute
	{
		public DeleteProductSpecific(int specificId, Guid productGuid) 
		{
			SpecificId = specificId; 
			ProductGuid = productGuid; 
		}

		public int SpecificId { get; set; }

		public Guid ProductGuid { get; set; }

		public object? GetParameters() => this;

		public string GetSql() => $@"DELETE FROM {DatabaseTable.ProductsSpecifics} WHERE ProductGuid = @ProductGuid AND SpecificId = @SpecificId;";
	}
}
