using FlipBuddy.Domain.Models;

namespace FlipBuddy.Persistence.DTO
{
	public class ProductSpecifics_DTO
	{
		public int SpecificId { get; set; }
		public Guid ProductGuid { get; set; }
		public string SpecificName { get; set; } = string.Empty;

		public ProductSpecific AsDomainProductSpecific() => new ProductSpecific(SpecificId, ProductGuid, SpecificName);
	}
}
