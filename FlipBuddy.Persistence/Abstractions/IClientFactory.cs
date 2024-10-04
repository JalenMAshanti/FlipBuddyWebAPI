namespace FlipBuddy.Persistence.Abstractions
{
	internal interface IClientFactory
	{
		public HttpClient CreateNewClient();
	}
}
