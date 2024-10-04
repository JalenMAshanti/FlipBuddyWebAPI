namespace FlipBuddy.Application.Abstraction
{
	public interface IHandlerFactory
	{
		public IBaseHandler NewHandler<Trequest>(Trequest request);
	}
}
