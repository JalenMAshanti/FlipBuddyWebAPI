using FlipBuddy.Application.Abstraction;
using FlipBuddy.Domain.Validation;
using FlipBuddy.Domain.Validation.GuidValidation;

namespace FlipBuddy.Application.Requests.ProductRequests.Update
{
    public class UpdateProductByGuidAndUserGuidRequest : IValidatable, IRequest
    {

        public UpdateProductByGuidAndUserGuidRequest() { }

        public UpdateProductByGuidAndUserGuidRequest(Guid guid,
                                    Guid userGuid,
                                    string title,
                                    int categoryId,
                                    decimal purchasedPrice,
                                    decimal sellPrice,
                                    string description,
                                    int quantity,
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
            ConditionId = conditionId;
            BarCode = barCode;
            DateSold = dateSold;
        }

        public Guid Guid { get; set; }
        public Guid UserGuid { get; set; }
        public string? Title { get; set; }
        public int CategoryId { get; set; }
        public decimal PurchasedPrice { get; set; }
        public decimal SellPrice { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public string? Currency { get; set; }
        public int ConditionId { get; set; }
        public string? BarCode { get; set; }
        public string? DateSold { get; set; }


        public bool IsValid(out Validator validator)
        {
            validator = new(
                new GuidRequiredRule(Guid, nameof(Guid)),
                new GuidRequiredRule(UserGuid, nameof(UserGuid))
            );

            return validator.IsPassingAllRules;
        }
    }
}
