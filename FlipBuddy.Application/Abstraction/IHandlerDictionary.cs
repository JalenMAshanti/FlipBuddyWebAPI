namespace FlipBuddy.Application.Abstraction
{
	public interface IHandlerDictionary
	{
		/// This method takes in the requestType and returns the Type of IHandler that handles the requestType.
		public Type? GetHandlerType(Type requestType);
	}
}
