using FlipBuddy.Persistence.Implementation;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace FlipBuddy.Persistence.Abstractions
{
	public abstract class APIService
	{
		public APIService(ClientFactory clientFactory) => _clientFactory = clientFactory;


		private readonly ClientFactory _clientFactory;


		public async Task<TResponse> GetAPIResponse<TResponse>(string _url)
		{
			var client = _clientFactory.CreateNewClient();

			var response = await client.GetStringAsync(_url);

			var result = JsonConvert.DeserializeObject<TResponse>(response);

			if (result == null)
			{
				throw new OperationCanceledException();
			}

			return result;
		}


		public async Task<TResponse> GetAPIResponse<TResponse>(string _url, string header, string headerContent)
		{
			var client = _clientFactory.CreateNewClient();

			client.DefaultRequestHeaders.Add(header, headerContent);

			client.DefaultRequestHeaders.Add("key_type", "3scale");

			var response = await client.GetStringAsync(_url);

			var result = JsonConvert.DeserializeObject<TResponse>(response);

			if (result == null)
			{
				throw new OperationCanceledException();
			}

			client.Dispose();

			return result;
		}



		public async Task<IEnumerable<TResponse>> GetListAPIResponse<TResponse>(string _url)
		{
			try
			{
				var client = _clientFactory.CreateNewClient();

				var response = await client.GetStringAsync(_url);

				var result = JsonConvert.DeserializeObject<IEnumerable<TResponse>>(response);

				if (result == null) 
				{
					throw new OperationCanceledException();
				}

				return result;
			}
			catch
			{

				return new List<TResponse>();
			}
		}

		public async Task<string> PostAPIRequest(string _url, Object body)
		{
			var client = _clientFactory.CreateNewClient();

			client.BaseAddress = new Uri(_url);

			string json = JsonSerializer.Serialize(body);

			var data = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("", data);

			var result = await response.Content.ReadAsStringAsync();

			return result;
		}
	}
}
