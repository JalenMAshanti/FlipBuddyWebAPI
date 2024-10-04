using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.BaseDataRequests;
using FlipBuddy.Persistence.DTO;

namespace FlipBuddy.Persistence.DataRequestObjects.ProductRequests
{
	public class GetProductsByUserGuid : GuidDataRequest, IDataFetch<Products_DTO>
	{
		public GetProductsByUserGuid(Guid guid) : base(guid){}
		public override string GetSql() => $"SELECT * FROM {DatabaseTable.Products} WHERE UserGuid = @Guid";	
	}
}
