using FlipBuddy.Application.Requests.UserRequests.GetByGuid;

namespace FlipBuddy.Application.Tests.RequestTests.UserRequestTests.GetUserByGuidTests
{
	public class GetUserByGuidRequestTests
	{
		#region Happy Path
		[Fact]
		public void GetUserByGuidRequest_Given_EventGuidIsValid_IsValid_ShouldReturn_True()
		{
			var request = new GetUserByGuidRequest(Guid.NewGuid());

			Assert.True(request.IsValid(out _));
		}
		#endregion

		#region Bad Paths

		[Fact]
		public void GetUserByGuidRequest_Given_EventGuidNotSet_IsValid_ShouldReturn_False() 
		{
			var request = new GetUserByGuidRequest();

			Assert.False(request.IsValid(out _));
		}

		[Fact]
		public void GetUserByGuidRequest_Given_EventGuidIsEmpty_IsValid_ShouldReturn_False()
		{
			var request = new GetUserByGuidRequest(Guid.Empty);

			Assert.False(request.IsValid(out _));
		}
		#endregion
	}
}
