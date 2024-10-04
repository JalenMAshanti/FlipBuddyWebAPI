using FlipBuddy.Application.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace FlipBuddy.Application.Implementation
{
	public class TypeActivator : ITypeActivator
	{
		private readonly IServiceProvider _serviceProvider;

		public TypeActivator(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public TResponse Instantiate<TResponse>(Type typeToInstantiate) => (TResponse)ActivatorUtilities.CreateInstance(_serviceProvider, typeToInstantiate);	
	}
}
