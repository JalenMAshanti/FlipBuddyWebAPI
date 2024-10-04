using FlipBuddy.Application.Abstraction;
using FlipBuddy.Persistence.Abstractions;
using FlipBuddy.Persistence.Implementation;

namespace FlipBuddy.Application.BaseObjects.BaseHandlers
{
	internal abstract class DataRequestHandlerAPIService<TRequest> : BaseRequestHandler<TRequest> where TRequest : IRequest
	{
		protected readonly IDataAccess _dataAccess;

		protected readonly ExternalAPIService _externalAPIService;
		protected DataRequestHandlerAPIService(IDataAccess dataAccess, ExternalAPIService externalAPIService)
		{ 
			_dataAccess = dataAccess;

			_externalAPIService = externalAPIService;
		} 
	}
}
