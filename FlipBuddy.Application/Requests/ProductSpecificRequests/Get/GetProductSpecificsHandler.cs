using FlipBuddy.Application.BaseObjects.BaseHandlers;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Domain.Models;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests;

namespace FlipBuddy.Application.Requests.ProductSpecificRequests.Get
{
    internal class GetProductSpecificsHandler : DataRequestResponseHandler<GetProductSpecificsRequest, GetProductSpecificsResponse>
    {
        public GetProductSpecificsHandler(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public override async Task<GetProductSpecificsResponse> GetResponseAsync(GetProductSpecificsRequest request)
        {
            try
            {
                var productSpecifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(request.ProductGuid));

                if (!productSpecifics.Any() || productSpecifics == null)
                {
                    return new GetProductSpecificsResponse(Enumerable.Empty<ProductSpecific>());
                }

                return new GetProductSpecificsResponse(productSpecifics.Select(_ => _.AsDomainProductSpecific()).ToList());
            }
            catch
            {
                throw new OperationFailedException();
            }
        }
    }
}
