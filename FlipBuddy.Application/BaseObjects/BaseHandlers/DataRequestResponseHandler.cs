using FlipBuddy.Application.Abstraction;
using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Application.BaseObjects.BaseHandlers
{
	internal abstract class DataRequestResponseHandler<TRequest, TResponse> : BaseRequestResponseHandler<TRequest, TResponse> where TRequest : IRequestResponse<TResponse>
	{
		protected readonly IDataAccess _dataAccess;
		protected DataRequestResponseHandler(IDataAccess dataAccess) => _dataAccess = dataAccess;
	}
}
