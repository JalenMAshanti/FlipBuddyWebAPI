using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Persistence.DTO;
using FlipBuddy.Tests.Shared.Constants;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ProductSpecificTests
{
    public class DeleteProductSpecificTests : BaseDataRequestTest
    {
        #region Happy Path
        [Fact]
        public async Task DeleteProductSpecific_Given_ProductExistsAndIdIsCorrect_ShouldReturnOneRowAffected()
        {
            //Insert User
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            //Insert Product
            var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

            //Insert ProductSpecific
            await _dataAccess.ExecuteAsync(new InsertProductSpecific(product_DTO.Guid, TestValues.SpecificName));

            //Get ProductSpecifics
            var specifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(product_DTO.Guid));
            ProductSpecifics_DTO productSpecific_DTO = specifics.Where(_ => _.SpecificName == TestValues.SpecificName).First();

            //Delete ProductSpecifics(TESTING)
            var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductSpecific(productSpecific_DTO.SpecificId, productSpecific_DTO.ProductGuid));

            //Test Result
            Assert.Equal(1, rowsAffected);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
        }
        #endregion

        #region Bad Paths
        [Fact]
        public async Task DeleteProductSpecific_Given_ProductGuidDoesNotExist_ShouldReturnZeroRowsAffected()
        {
            //Insert User
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            //Insert Product
            var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

            //Insert ProductSpecific
            await _dataAccess.ExecuteAsync(new InsertProductSpecific(product_DTO.Guid, TestValues.SpecificName));

            //Get ProductSpecifics
            var specifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(product_DTO.Guid));
            ProductSpecifics_DTO productSpecific_DTO = specifics.Where(_ => _.SpecificName == TestValues.SpecificName).First();

            //Delete ProductSpecifics(TESTING)
            var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductSpecific(productSpecific_DTO.SpecificId, Guid.NewGuid()));

            //Test Result
            Assert.Equal(0, rowsAffected);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
        }

        [Fact]
        public async Task DeleteProductSpecific_Given_SpecificIdDoesNotExist_ShouldReturnZeroRowsAffected()
        {
            //Insert User
            var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

            //Insert Product
            var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

            //Insert ProductSpecific
            await _dataAccess.ExecuteAsync(new InsertProductSpecific(product_DTO.Guid, TestValues.SpecificName));

            //Get ProductSpecifics
            var specifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(product_DTO.Guid));
            ProductSpecifics_DTO productSpecific_DTO = specifics.Where(_ => _.SpecificName == TestValues.SpecificName).First();

            //Delete ProductSpecifics(TESTING)
            var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductSpecific(int.MaxValue, productSpecific_DTO.ProductGuid));

            //Test Result
            Assert.Equal(0, rowsAffected);

            //Clean up
            await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
            await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
        }

        [Fact]
        public async Task DeleteProductSpecific_Given_SpecificIdAndProductGuidDoesNotExist_ShouldReturnZeroRowsAffected()
        {
            //Delete ProductSpecifics(TESTING)
            var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteProductSpecific(int.MaxValue, Guid.NewGuid()));

            //Test Result
            Assert.Equal(0, rowsAffected);
        }
        #endregion
    }
}
