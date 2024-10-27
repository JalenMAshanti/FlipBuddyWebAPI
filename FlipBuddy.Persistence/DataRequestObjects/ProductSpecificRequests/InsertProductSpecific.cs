using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests
{
	public class InsertProductSpecific : IDataExecute
	{
		public InsertProductSpecific( Guid productGuid, string specificName) 
		{
			ProductGuid = productGuid;
			SpecificName = specificName;
		}

		public Guid ProductGuid { get; set; }

		public string SpecificName { get; set; } = string.Empty;
		
		public object? GetParameters() => this;

		public string GetSql() => $@"INSERT INTO {DatabaseTable.ProductsSpecifics} (ProductGuid, SpecificName) VALUES (@ProductGuid, @SpecificName);";
	}
}
