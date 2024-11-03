using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests;
using FlipBuddy.Persistence.DTO;
using FlipBuddy.Tests.Shared.Constants;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ProductSpecificTests
{
    public class InsertProductSpecificTests : BaseDataRequestTest
    {
        #region Happy Path
        [Fact]
        public async Task InsertProductSpecific_Given_ProductExists_ShouldReturnOneRowAffected()
        {
            //Insert User
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            //Insert Product
            var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

            //Insert ProductSpecific(TESTING)
            var rowsAffected = await _dataAccess.ExecuteAsync(new InsertProductSpecific(product_DTO.Guid, TestValues.SpecificName));

            //Get ProductSpecific
            var specifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(product_DTO.Guid));
            ProductSpecifics_DTO productSpecific_DTO = specifics.Where(_ => _.SpecificName == TestValues.SpecificName).First();

            //Test Result
            Assert.Equal(1, rowsAffected);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteProductSpecific(productSpecific_DTO.SpecificId, productSpecific_DTO.ProductGuid));
        }
        #endregion

        #region Bad Paths
        [Fact]
        public async Task InsertProductSpecific_Given_ProductDoesNotExist_ShouldReturnDataAccessException()
        {
            //Insert ProductSpecific(TESTING)
            var exception = await Record.ExceptionAsync(async () => await _dataAccess.ExecuteAsync(new InsertProductSpecific(Guid.NewGuid(), TestValues.SpecificName)));

            //Test Result
            Assert.IsType<DataAccessException>(exception);
        }
        #endregion
    }
}
