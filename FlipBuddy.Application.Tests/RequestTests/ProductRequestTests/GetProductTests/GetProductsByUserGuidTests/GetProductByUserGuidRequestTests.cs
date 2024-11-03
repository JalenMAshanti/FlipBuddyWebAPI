using FlipBuddy.Application.Requests.ProductRequests.GetByUserGuid;

namespace FlipBuddy.Application.Tests.RequestTests.ProductRequestTests.GetProductTests.GetProductsByUserGuidTests
{
    public class GetProductByUserGuidRequestTests
    {
        #region Happy Path
        [Fact]
        public void GetProductByUserGuidRequest_Given_EventGuidIsValid_IsValid_ShouldReturn_True()
        {
            var request = new GetProductsByUserGuidRequest(Guid.NewGuid());

            Assert.True(request.IsValid(out _));
        }
        #endregion

        #region Bad Paths
        [Fact]
        public void GetProductByUserGuidRequest_Given_EventGuidIsEmpty_IsValid_ShouldReturn_False()
        {
            var request = new GetProductsByUserGuidRequest(Guid.Empty);

            Assert.False(request.IsValid(out _));
        }

        [Fact]
        public void GetProductByUserGuidRequest_Given_EventGuidIsNull_IsValid_ShouldReturn_False()
        {
            var request = new GetProductsByUserGuidRequest();

            Assert.False(request.IsValid(out _));
        }
        #endregion
    }
}
