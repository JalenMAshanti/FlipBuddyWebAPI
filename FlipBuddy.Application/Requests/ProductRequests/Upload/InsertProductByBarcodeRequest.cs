using FlipBuddy.Application.Abstraction;
using FlipBuddy.Domain.Validation;
using FlipBuddy.Domain.Validation.GuidValidation;
using Microsoft.AspNetCore.Http;

namespace FlipBuddy.Application.Requests.ProductRequests.Upload
{
    public class InsertProductByBarcodeRequest : IValidatable, IRequest
    {
        public InsertProductByBarcodeRequest() { }

        public InsertProductByBarcodeRequest(IFormFile image, Guid guid, Guid userGuid)
        {
            Image = image;
            Guid = guid;
            UserGuid = userGuid;
        }

        public IFormFile? Image { get; set; }

        public Guid Guid { get; set; }

        public Guid UserGuid { get; set; }

        public bool IsValid(out Validator validator)
        {
            validator = new(
                new GuidRequiredRule(Guid, nameof(Guid)),
                new GuidRequiredRule(UserGuid, nameof(Guid))
            );

            return validator.IsPassingAllRules;
        }
    }
}
