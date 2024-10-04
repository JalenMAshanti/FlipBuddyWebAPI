namespace FlipBuddy.Application.Abstraction
{
	public interface ITypeActivator
	{
		public TResponse Instantiate<TResponse>(Type typeToInstantiate);
	}
}
