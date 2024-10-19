namespace FlippBuddy.Domain.Models
{
    public class Product
    {
        public Product() { }

        public Product(Guid guid,
                       Guid userGuid,
                       string title,
                       int categoryId,
                       decimal purchasedPrice,
                       decimal sellPrice,
                       string description,   
                       int quantity,
                       string currency,
                       int conditionId,
                       string barCode,
                       string dateSold) 
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
            DateSold = dateSold;
        }

        public Guid? Guid { get; set; }
        public Guid? UserGuid { get; set; }
        public string? Title { get; set; }
        public int CategoryId { get; set; }
        public decimal PurchasedPrice { get; set; }
        public decimal SellPrice { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public string? Currency { get; set; }
        public int? ConditionId { get; set; }
		public string BarCode { get; set; } = string.Empty;
        public string DateSold { get; set; } = string.Empty;
	}
}
