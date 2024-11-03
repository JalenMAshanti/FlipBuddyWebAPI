using FlipBuddy.Application.Requests.ProductSpecificRequests.Get;

namespace FlipBuddy.Application.Tests.RequestTests.ProductSpecificRequestTests.GetProductSpecificTests
{
    public class GetProductSpecificRequestTests
    {
        #region Happy Path
        [Fact]
        public void GetProductSpecificRequest_Given_EventGuidIsValid_IsValid_ShouldReturn_True()
        {
            var request = new GetProductSpecificsRequest(Guid.NewGuid());

            Assert.True(request.IsValid(out _));
        }
        #endregion

        #region Bad Paths
        [Fact]
        public void GetProductSpecificRequest_Given_EventGuidIsEmpty_IsValid_ShouldReturn_False()
        {
            var request = new GetProductSpecificsRequest(Guid.Empty);

            Assert.False(request.IsValid(out _));
        }
        #endregion
    }
}
