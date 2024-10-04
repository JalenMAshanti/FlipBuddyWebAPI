using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Persistence.Implementation
{
	public class ClientFactory : IClientFactory
	{
		public HttpClient CreateNewClient()
		{
			HttpClient client = new HttpClient();
			return client;
		}
	}
}
