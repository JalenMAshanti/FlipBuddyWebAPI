using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DTO;

namespace FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests
{
	public class GetProductSpecifics : IDataFetch<ProductSpecifics_DTO>
	{
		public GetProductSpecifics(Guid productGuid) 
		{
			ProductGuid = productGuid;
		}

		public Guid ProductGuid { get; set; }

		public object? GetParameters() => this;

		public string GetSql() => $@"SELECT * FROM {DatabaseTable.ProductsSpecifics} WHERE ProductGuid = @ProductGuid";
	}
}
