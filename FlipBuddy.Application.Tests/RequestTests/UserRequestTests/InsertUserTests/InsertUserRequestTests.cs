using FlipBuddy.Application.Requests.UserRequests.Insert;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Application.Tests.RequestTests.UserRequestTests.InsertUserTests
{
    public class InsertUserRequestTests
    {
        #region Happy Path
        [Fact]
        public void InsertUserRequest_Given_RequestInputsAreValid_IsValid_ShouldReturnTrue()
        {
            var request = new InsertUserRequest(Guid.NewGuid(),
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random()
                                                );

            Assert.True(request.IsValid(out _));
        }
        #endregion

        #region BadPaths
        //Guid Validator Tests
        [Fact]
        public void InsertUserRequest_Given_EventGuidNotSet_IsValid_ShouldReturnFalse()
        {
            var request = new InsertUserRequest(Guid.Empty,
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random()
                                                );

            Assert.False(request.IsValid(out _));
        }

        //Username Validator Tests
        [Fact]
        public void InsertUserRequest_Given_UsernameIsEmpty_IsValid_ShouldReturnFalse()
        {
            var request = new InsertUserRequest(Guid.NewGuid(),
                                                string.Empty,
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random()
                                                );

            Assert.False(request.IsValid(out _));
        }

        [Fact]
        public void InsertUserRequest_Given_UsernameIsNull_IsValid_ShouldReturnFalse()
        {
            var request = new InsertUserRequest(Guid.NewGuid(),
                                                null,
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random()
                                                );

            Assert.False(request.IsValid(out _));
        }

        [Fact]
        public void InsertUserRequest_Given_UsernameTooLong_IsValid_ShouldReturnFalse()
        {
            var request = new InsertUserRequest(Guid.NewGuid(),
                                                TestString.Random(65),
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random()
                                                );

            Assert.False(request.IsValid(out _));
        }




        //Firstname Validator Tests
        [Fact]
        public void InsertUserRequest_Given_FirstnameIsEmpty_IsValid_ShouldReturnFalse()
        {
            var request = new InsertUserRequest(Guid.NewGuid(),
                                                TestString.Random(),
                                                string.Empty,
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random()
                                                );

            Assert.False(request.IsValid(out _));
        }

        [Fact]
        public void InsertUserRequest_Given_FirstnameIsNull_IsValid_ShouldReturnFalse()
        {
            var request = new InsertUserRequest(Guid.NewGuid(),
                                                TestString.Random(),
                                                null,
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random()
                                                );

            Assert.False(request.IsValid(out _));
        }

        [Fact]
        public void InsertUserRequest_Given_FirstnameTooLong_IsValid_ShouldReturnFalse()
        {
            var request = new InsertUserRequest(Guid.NewGuid(),
                                                TestString.Random(),
                                                TestString.Random(65),
                                                TestString.Random(),
                                                TestString.Random(),
                                                TestString.Random()
                                                );

            Assert.False(request.IsValid(out _));
        }

        #endregion
    }
}
