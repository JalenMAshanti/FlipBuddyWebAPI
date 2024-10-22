using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Persistence.DataRequestObjects.ProductRequests
{
    public class UpdateProductByGuidAndUserGuid : IDataExecute
    {


        public UpdateProductByGuidAndUserGuid(Guid guid,
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


        public UpdateProductByGuidAndUserGuid(Guid guid,
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
                                                string dateSold
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
            DateSold = dateSold;
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
        public string? DateSold { get; set; }


        public object? GetParameters() => this;

        public string GetSql() => $@"
                                    UPDATE Products
                                    SET 
                                        Title = @Title, 
                                        CategoryId = @CategoryId,
                                        PurchasedPrice = @PurchasedPrice,
                                        SellPrice = @SellPrice,
                                        Description = @Description,
                                        Quantity = @Quantity,
                                        Currency = @Currency,
                                        ConditionId = @ConditionId,
                                        BarCode = @BarCode,
                                        DateSold = @DateSold
                                    WHERE 
                                        Guid = @Guid AND UserGuid = @UserGuid;";
    }
}
