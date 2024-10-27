using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Persistence.DataRequestObjects.ProductSpecificValueRequests
{
	public class DeleteProductSpecificValue : IDataExecute
	{
		public DeleteProductSpecificValue(int valueId, int specificId)
		{
			ValueId = valueId;
			SpecificId = specificId;
		}

		public int ValueId { get; set; }
		public int SpecificId { get; set; }


		public object? GetParameters() => this;
		public string GetSql() => $@"DELETE FROM {DatabaseTable.ProductsSpecificValues} WHERE ValueId = @ValueId AND SpecificId = @SpecificId;";
	}
}
