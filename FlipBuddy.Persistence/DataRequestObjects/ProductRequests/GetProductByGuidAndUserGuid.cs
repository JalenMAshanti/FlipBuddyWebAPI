using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DTO;

namespace FlipBuddy.Persistence.DataRequestObjects.ProductRequests
{
	public class GetProductByGuidAndUserGuid : IDataFetch<Products_DTO>
	{
		public GetProductByGuidAndUserGuid(Guid userGuid, Guid productGuid) 
		{
			UserGuid = userGuid;

			ProductGuid = productGuid;
		}

		public Guid UserGuid { get; set; }
		public Guid ProductGuid { get; set; }

		public object? GetParameters() => this;

		public string GetSql() => $@"SELECT * FROM {DatabaseTable.Products} WHERE UserGuid = @UserGuid AND Guid = @ProductGuid";
	}
}
