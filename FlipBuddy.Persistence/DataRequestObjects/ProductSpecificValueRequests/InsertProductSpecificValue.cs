using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Persistence.DataRequestObjects.ProductSpecificValueRequests
{
	public class InsertProductSpecificValue : IDataExecute
	{
		public InsertProductSpecificValue(int specificId, string specificValue)
		{
			SpecificId = specificId;
			SpecificValue = specificValue;
		}

		public int SpecificId { get; set; }
		public string SpecificValue { get; set; } = string.Empty;

		public object? GetParameters() => this;
		public string GetSql() => $@"INSERT INTO {DatabaseTable.ProductsSpecifics} (ProductGuid, SpecificName) VALUES (@ProductGuid, @SpecificName);";
	}
}
