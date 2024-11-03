using FlipBuddy.Domain.Constants;
using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Tests.Shared.Constants;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.UserTests
{
    public class InsertUserTests : BaseDataRequestTest
    {
        #region Happy Path
        [Fact]
        public async Task InsertUser_Given_InputIsValid_ShouldReturn_OneRowAffected()
        {
            //Insert User
            var guid = Guid.NewGuid();
            var rowsaffected = await _dataAccess.ExecuteAsync(new InsertUser(
                                        guid,
                                        TestString.Random(),
                                        TestValues.UserFirstName,
                                        TestString.Random(),
                                        TestString.Random(),
                                        TestString.Random(),
                                        TestString.Random(),
                                        TestNumber.GetSubTier(),
                                        DefaultValues.DefaultFlipsAmount
                                        ));


            //Test Result
            Assert.Equal(1, rowsaffected);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(guid));
        }
        #endregion


        #region Bad Paths
        [Fact]
        public async Task InsertUser_Given_GuidAlreadyTaken_ShouldThrowDataAccessException()
        {
            //Insert User
            var guid = Guid.NewGuid();
            var insertUser = new InsertUser(
                                            guid,
                                            TestString.Random(),
                                            TestValues.UserFirstName,
                                            TestString.Random(),
                                            TestString.Random(),
                                            TestString.Random(),
                                            TestString.Random(),
                                            TestNumber.GetSubTier(),
                                            DefaultValues.DefaultFlipsAmount
                                            );

            await _dataAccess.ExecuteAsync(insertUser);


            //Insert Second User
            var insertUserWithSameGuid = new InsertUser(
                                                        guid,
                                                        TestString.Random(),
                                                        TestValues.UserFirstName,
                                                        TestString.Random(),
                                                        TestString.Random(),
                                                        TestString.Random(),
                                                        TestString.Random(),
                                                        TestNumber.GetSubTier(),
                                                        DefaultValues.DefaultFlipsAmount
                                                        );

            var exception = await Record.ExceptionAsync(async () => await _dataAccess.ExecuteAsync(insertUserWithSameGuid));

            //Test Result
            Assert.IsType<DataAccessException>(exception);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(guid));
        }


        [Fact]
        public async Task InsertUser_Given_UsernameAlreadyTaken_ShouldThrowDataAccessException()
        {
            //Insert User
            var guid = Guid.NewGuid();
            var username = TestString.Random();
            var insertUser = new InsertUser(
                                            guid,
                                            username,
                                            TestValues.UserFirstName,
                                            TestString.Random(),
                                            TestString.Random(),
                                            TestString.Random(),
                                            TestString.Random(),
                                            TestNumber.GetSubTier(),
                                            DefaultValues.DefaultFlipsAmount
                                            );

            await _dataAccess.ExecuteAsync(insertUser);

            //Insert Second User
            var insertUserWithSameUsername = new InsertUser(
                                                        Guid.NewGuid(),
                                                        username,
                                                        TestValues.UserFirstName,
                                                        TestString.Random(),
                                                        TestString.Random(),
                                                        TestString.Random(),
                                                        TestString.Random(),
                                                        TestNumber.GetSubTier(),
                                                        DefaultValues.DefaultFlipsAmount
                                                        );

            var exception = await Record.ExceptionAsync(async () => await _dataAccess.ExecuteAsync(insertUserWithSameUsername));


            //Test Result
            Assert.IsType<DataAccessException>(exception);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(guid));
        }

        #endregion
    }
}
