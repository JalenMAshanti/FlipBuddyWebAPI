using FlipBuddy.Application.Requests.ProductRequests.GetByGuidAndUserGuid;

namespace FlipBuddy.Application.Tests.RequestTests.ProductRequestTests.GetProductTests.GetByGuidAndUserGuidTests
{
    public class GetProductByGuidAndUserGuidRequestTests
    {
        #region Happy Path
        [Fact]
        public void GetProductByGuidAndUserGuidRequest_Given_EventGuidsAreValid_IsValid_ShouldReturn_True()
        {
            var request = new GetProductByGuidAndUserGuidRequest(Guid.NewGuid(),
                                                                 Guid.NewGuid()
                                                                 );

            Assert.True(request.IsValid(out _));
        }
        #endregion

        #region Bad Path
        [Fact]
        public void GetProductByGuidAndUserGuidRequest_Given_GuidIsEmpty_IsValid_ShouldReturn_False()
        {
            var request = new GetProductByGuidAndUserGuidRequest(Guid.Empty,
                                                                 Guid.NewGuid()
                                                                 );

            Assert.False(request.IsValid(out _));
        }

        [Fact]
        public void GetProductByGuidAndUserGuidRequest_Given_ProductGuidIsEmpty_IsValid_ShouldReturn_False()
        {
            var request = new GetProductByGuidAndUserGuidRequest(Guid.NewGuid(),
                                                                 Guid.Empty
                                                                 );

            Assert.False(request.IsValid(out _));
        }
        #endregion
    }
}
