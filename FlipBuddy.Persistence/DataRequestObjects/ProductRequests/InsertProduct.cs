using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Persistence.DataRequestObjects.ProductRequests
{
	public class InsertProduct : IDataExecute
	{
		InsertProduct() { }

		public InsertProduct(Guid guid,
					   Guid userGuid,
					   string title,
					   int categoryId,
					   decimal purchasedPrice,
					   decimal sellPrice,
					   string description,
					   int quantity,
					   string currency,
					   int conditionId,
					   string barCode
					   )
		{
			Guid = guid;
			UserGuid = userGuid;
			Title = title;
			CategoryId = categoryId;
			PurchasedPrice = purchasedPrice;
			SellPrice = sellPrice;
			Description = description;
			Quantity = quantity;
			Currency = currency;
			ConditionId = conditionId;
			BarCode = barCode;
		}

		public Guid? Guid { get; set; }
		public Guid? UserGuid { get; set; }
		public string? Title { get; set; } = string.Empty;
		public int CategoryId { get; set; }
		public decimal PurchasedPrice { get; set; }
		public decimal SellPrice { get; set; }
		public string? Description { get; set; } = string.Empty;
		public int Quantity { get; set; }
		public string? Currency { get; set; } = string.Empty;
		public int ConditionId { get; set; }
		public string BarCode { get; set; } = string.Empty;

		public object? GetParameters() => this;

		public string GetSql() => $@"
									INSERT INTO {DatabaseTable.Products} 
									(Guid, UserGuid, Title, CategoryId, PurchasedPrice, SellPrice, Description, Quantity, Currency, ConditionId, BarCode) 
									VALUES 
									(@Guid, @UserGuid, @Title, @CategoryId, @PurchasedPrice, @SellPrice, @Description, @Quantity, @Currency, @ConditionId, @BarCode
								  );";
		
	}
}
