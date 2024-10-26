using FlipBuddy.Application.Abstraction;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.Implementation;

namespace FlipBuddy.Application.BaseObjects.BaseHandlers
{
	internal abstract class DataRequestResponseHandler<TRequest, TResponse> : BaseRequestResponseHandler<TRequest, TResponse> where TRequest : IRequestResponse<TResponse>
	{
		protected readonly IDataAccess _dataAccess;
		protected readonly ExternalAPIService? _apiService;
		protected readonly EbayAPIService? _ebayAPISerice;
		protected DataRequestResponseHandler(IDataAccess dataAccess) => _dataAccess = dataAccess;

		protected DataRequestResponseHandler(IDataAccess dataAccess, ExternalAPIService apiService)
		{
			_dataAccess = dataAccess;
			_apiService = apiService;
		}

		protected DataRequestResponseHandler(IDataAccess dataAccess, EbayAPIService ebayApiService)
		{
			_dataAccess = dataAccess;
			_ebayAPISerice = ebayApiService;
		}
	}
}
