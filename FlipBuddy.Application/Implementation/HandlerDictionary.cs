using FlipBuddy.Application.Abstraction;
using FlipBuddy.Domain.Exceptions;

namespace FlipBuddy.Application.Implementation
{
	public class HandlerDictionary : IHandlerDictionary
	{

		private readonly Dictionary<Type, Type> _handlersDictionary;

		public HandlerDictionary() 
		{
			// get the types from the applilcation layer where they implement the interface IBaseHandler and is a class
			var handlers = GetType().Assembly.GetTypes().Where(x => typeof(IBaseHandler).IsAssignableFrom(x) && x.IsClass);
		
			_handlersDictionary = GetHandlersDictionary(handlers);
		}

		public Type? GetHandlerType(Type requestType) => _handlersDictionary.TryGetValue(requestType, out var result) ? result : null;

		private static Dictionary<Type, Type> GetHandlersDictionary(IEnumerable<Type> handlers) =>
		   handlers.ToDictionary(_ => _.GetInterfaces()
									   .FirstOrDefault(_ => _.GenericTypeArguments.Any())?
									   .GenericTypeArguments.First()
									   ?? throw new DoesNotExistException("RequestObject", (_, _.Name)));
	}
}
