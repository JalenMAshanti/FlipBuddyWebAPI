using FlippBuddy.Domain.Models;

namespace FlipBuddy.Persistence.DTO
{
	public class Products_DTO
	{
		public Guid Guid { get; set; }
		public Guid UserGuid { get; set; }
		public string Title { get; set; } = string.Empty;
		public int CategoryId { get; set; }
		public decimal PurchasedPrice { get; set; }
		public decimal SellPrice { get; set; }
		public string Description { get; set; } = string.Empty;
		public int Quantity { get; set; }
		public string Currency { get; set; } = string.Empty;
		public int ConditionId { get; set; }
		public string BarCode { get; set; } = string.Empty;
		public string DateSold { get; set; } = string.Empty;

		public Product AsDomainProduct() => new(Guid, UserGuid, Title, CategoryId, PurchasedPrice, SellPrice, Description, Quantity, Currency, ConditionId, BarCode, DateSold);
	}
}
