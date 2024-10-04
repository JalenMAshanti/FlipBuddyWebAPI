namespace FlipBuddy.Application.Abstraction
{
	internal interface IRequestResponseHandler<TRequest, TResponse> : IBaseHandler where TRequest : IRequestResponse<TResponse>
	{
		public Task<TResponse> GetResponseAsync(TRequest request);
	}
}
