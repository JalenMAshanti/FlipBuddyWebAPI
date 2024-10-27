using System.Runtime.CompilerServices;

namespace FlipBuddy.Domain.Models
{
	public class ProductSpecific
	{
		public ProductSpecific() { }

		public ProductSpecific(int specificId, Guid productGuid, string specificName) 
		{
			SpecificId = specificId;
			ProductGuid = productGuid;
			SpecificName = specificName;
		}

		public int SpecificId { get; set; }
		public Guid ProductGuid { get; set; }
		public string SpecificName { get; set; } = string.Empty;
	}
}
