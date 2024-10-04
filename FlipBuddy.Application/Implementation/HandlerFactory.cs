using FlipBuddy.Application.Abstraction;
using FlipBuddy.Domain.Exceptions;

namespace FlipBuddy.Application.Implementation
{
	public class HandlerFactory : IHandlerFactory
	{
		private readonly IHandlerDictionary? _handlers;

		private readonly ITypeActivator? _typeActivator;


		public HandlerFactory(ITypeActivator typeActivator, IHandlerDictionary handlers) 
		{
			_handlers = handlers;
			_typeActivator = typeActivator;
		}


		public IBaseHandler NewHandler<TRequest>(TRequest request)
		{
			if (request == null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			var handlerType = _handlers.GetHandlerType(request.GetType());

			if (handlerType == null) 
			{
				throw new DoesNotExistException("RequestHandler", (request, nameof(request)));
			}

			return _typeActivator.Instantiate<IBaseHandler>(handlerType);
		}
	}
}
