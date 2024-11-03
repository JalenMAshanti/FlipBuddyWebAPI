using FlipBuddy.Application.Requests.ProductRequests.Upload;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Application.Tests.RequestTests.ProductRequestTests.InsertProductTests
{
    public class InsertProductByBarcodeRequestTests
    {
        #region Happy Path
        [Fact]
        public void InsertProductByBarcodeRequest_Given_EventGuidsAreValid_IsValid_ShouldReturn_True()
        {

            var request = new InsertProductByBarcodeRequest(TestFormFile.CreateEmptyFormFile(),
                                                            Guid.NewGuid(),
                                                            Guid.NewGuid()
                                                            );

            Assert.True(request.IsValid(out _));
        }
        #endregion

        #region Bad Paths
        [Fact]
        public void InsertProductByBarcodeRequest_Given_EventGuidIsEmpty_IsValid_ShouldReturn_False()
        {

            var request = new InsertProductByBarcodeRequest(TestFormFile.CreateEmptyFormFile(),
                                                            Guid.Empty,
                                                            Guid.NewGuid()
                                                            );

            Assert.False(request.IsValid(out _));
        }

        [Fact]
        public void InsertProductByBarcodeRequest_Given_UserGuidIsEmpty_IsValid_ShouldReturn_False()
        {

            var request = new InsertProductByBarcodeRequest(TestFormFile.CreateEmptyFormFile(),
                                                            Guid.NewGuid(),
                                                            Guid.Empty
                                                            );

            Assert.False(request.IsValid(out _));
        }
        #endregion
    }
}
