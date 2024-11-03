using FlipBuddy.Application.Requests.ProductSpecificRequests.Get;
using FlipBuddy.Application.Requests.ProductSpecificRequests.Insert;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Application.Tests.RequestTests.ProductSpecificRequestTests.InsertProductSpecificTests
{
    public class InsertProductSpecificRequestTest
    {
        #region Happy Path
        [Fact]
        public void InsertProductSpecificRequest_Given_EventGuidAndNameIsValid_IsValid_ShouldReturn_True()
        {
            var request = new InsertProductSpecificRequest(Guid.NewGuid(),
                                                           TestString.Random());

            Assert.True(request.IsValid(out _));
        }
        #endregion

        #region Bad Paths
        [Fact]
        public void InsertProductSpecificRequest_Given_EventGuidIsEmpty_IsValid_ShouldReturn_False()
        {
            var request = new InsertProductSpecificRequest(Guid.Empty,
                                                           TestString.Random());

            Assert.False(request.IsValid(out _));
        }



        [Fact]
        public void InsertProductSpecificRequest_Given_EventNameIsEmpty_IsValid_ShouldReturn_False()
        {
            var request = new InsertProductSpecificRequest(Guid.NewGuid(),
                                                           string.Empty);

            Assert.False(request.IsValid(out _));
        }


        [Fact]
        public void InsertProductSpecificRequest_Given_EventNameIsNull_IsValid_ShouldReturn_False()
        {
            var request = new InsertProductSpecificRequest(Guid.NewGuid(),
                                                           null);

            Assert.False(request.IsValid(out _));
        }

        [Fact]
        public void InsertProductSpecificRequest_Given_EventNameIsExceedMaxLength_IsValid_ShouldReturn_False()
        {
            var request = new InsertProductSpecificRequest(Guid.NewGuid(),
                                                           TestString.Random(77));

            Assert.False(request.IsValid(out _));
        }
        #endregion
    }
}
