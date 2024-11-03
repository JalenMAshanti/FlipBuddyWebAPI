using FlipBuddy.Application.Requests.ProductSpecificRequests.Delete;

namespace FlipBuddy.Application.Tests.RequestTests.ProductSpecificRequestTests.DeleteProductSpecificTests
{
    public class DeleteProductSpecificRequestTests
    {
        #region Happy Path
        [Fact]
        public void DeleteProductSpecificRequest_Given_EventGuidIsValid_IsValid_ShouldReturn_True()
        {
            var request = new DeleteProductSpecificRequest(int.MinValue,
                                                           Guid.NewGuid()
                                                           );

            Assert.True(request.IsValid(out _));
        }
        #endregion

        #region Bad Paths
        [Fact]
        public void DeleteProductSpecificRequest_Given_EventGuidIsEmpty_IsValid_ShouldReturn_False()
        {
            var request = new DeleteProductSpecificRequest(int.MinValue,
                                                           Guid.Empty
                                                           );

            Assert.False(request.IsValid(out _));
        }

        #endregion
    }
}
