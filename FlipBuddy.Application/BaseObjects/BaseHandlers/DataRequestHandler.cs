using FlipBuddy.Application.Abstraction;
using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Application.BaseObjects.BaseHandlers
{
	internal abstract class DataRequestHandler<TRequest> : BaseRequestHandler<TRequest> where TRequest : IRequest
	{
		protected readonly IDataAccess _dataAccess;
		protected DataRequestHandler(IDataAccess dataAccess) => _dataAccess = dataAccess;
	}
}
