using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Persistence.Implementation
{
	public class ExternalEbayAPIService : EbayAPIService
	{
		public ExternalEbayAPIService(ClientFactory clientFactory) : base(clientFactory)
		{
		}
	}
}
