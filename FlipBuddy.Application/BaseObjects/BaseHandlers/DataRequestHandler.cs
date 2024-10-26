using FlipBuddy.Application.Abstraction;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.Implementation;

namespace FlipBuddy.Application.BaseObjects.BaseHandlers
{
	internal abstract class DataRequestHandler<TRequest> : BaseRequestHandler<TRequest> where TRequest : IRequest
	{
		protected readonly IDataAccess _dataAccess;
		protected readonly ExternalAPIService? _apiService;
		protected readonly EbayAPIService? _ebayApiService;
		protected DataRequestHandler(IDataAccess dataAccess) => _dataAccess = dataAccess;
			
		protected DataRequestHandler(IDataAccess dataAccess, ExternalAPIService apiService)
		{
			_dataAccess = dataAccess;
			_apiService = apiService;
		}

		protected DataRequestHandler(IDataAccess dataAccess, EbayAPIService ebayApiService)
		{
			_dataAccess = dataAccess;
			_ebayApiService = ebayApiService;
		}
	}
}
