using FlipBuddy.Application.Requests.UserRequests.DeleteByGuid;

namespace FlipBuddy.Application.Tests.RequestTests.UserRequestTests.DeleteUserByGuidTests
{
    public class DeleteUserByGuidRequestTests
    {
        #region Happy Paths
        [Fact]
        public void DeleteUserByGuidRequest_Given_EventGuidIsValidGuid_IsValid_ShouldReturn_True()
        {
            var request = new DeleteUserByGuidRequest(Guid.NewGuid());

            Assert.True(request.IsValid(out _));
        }
        #endregion

        
        #region Bad Paths
        [Fact]
        public void DeleteUserByGuidRequest_Given_EventGuidNotSet_IsValid_ShouldReturn_False()
        {
            var request = new DeleteUserByGuidRequest();

            Assert.False(request.IsValid(out _));
        }

        [Fact]
        public void DeleteUserByGuidRequest_Given_EventGuidIsEmpty_IsValid_ShouldReturn_False()
        {
            var request = new DeleteUserByGuidRequest(Guid.Empty);

            Assert.False(request.IsValid(out _));
        }
        #endregion
    }
}
