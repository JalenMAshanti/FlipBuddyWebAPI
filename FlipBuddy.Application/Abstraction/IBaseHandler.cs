namespace FlipBuddy.Application.Abstraction
{
	public interface IBaseHandler
	{
		public Task<object?> HandleAsync(object request);
	}
}
