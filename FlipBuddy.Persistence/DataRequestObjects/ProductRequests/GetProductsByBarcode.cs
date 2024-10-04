using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DTO;

namespace FlipBuddy.Persistence.DataRequestObjects.ProductRequests
{
	public class GetProductsByBarcode : IDataFetch<Products_DTO>
	{
		public GetProductsByBarcode(string barCode)
		{
			BarCode = barCode;
		}

		string? BarCode { get; set; }

		public object? GetParameters() => new {BarCode};

		public string GetSql() => $"SELECT * FROM {DatabaseTable.Products} WHERE BarCode = @BarCode";
	}
}
