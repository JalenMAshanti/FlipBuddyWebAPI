using FlipBuddy.Domain.Models;

namespace FlipBuddy.Persistence.DTO
{
	public class ProductSpecificValues_DTO
	{
		public int ValueId { get; set; }
		public int SpecificId { get; set; }
		public string SpecificValue { get; set; } = string.Empty;

		public ProductSpecificValue AsDomainProductSpecificValue() => new ProductSpecificValue(ValueId, SpecificId, SpecificValue);
	}
}
