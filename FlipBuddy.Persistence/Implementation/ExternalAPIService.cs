using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Persistence.Implementation
{
	public class ExternalAPIService : APIService
	{
		public ExternalAPIService(ClientFactory clientFactory) : base(clientFactory)
		{
		}
	}
}
