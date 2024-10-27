using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.ProductSpecificRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Persistence.DTO;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ProductSpecificTests
{
	public class GetProductSpecificsTests : BaseDataRequestTest
	{
		#region Happy Path
		[Fact]
		public async Task GetProductSpecifics_Given_ProductExists_ShouldReturn_ListOfProductSpecifics_DTO()
		{
			var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

			var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

			var specificName = TestString.Random();

			var rowsAffected = await _dataAccess.ExecuteAsync(new InsertProductSpecific(product_DTO.Guid, specificName));

			var specifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(product_DTO.Guid));

			ProductSpecifics_DTO productSpecific_DTO = specifics.Where(_ => _.SpecificName == specificName).First();

			Assert.Equal(specificName, productSpecific_DTO.SpecificName);
			Assert.Equal(product_DTO.Guid, productSpecific_DTO.ProductGuid);

			await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
		}
		#endregion

		#region Bad Paths
		[Fact]
		public async Task GetProductSpecifics_Given_ProductDoesNotExist_ShouldReturn_EmptyListOfProductSpecifics_DTO()
		{
			var specifics = await _dataAccess.FetchListAsync(new GetProductSpecifics(Guid.NewGuid()));

			Assert.Empty(specifics);
		}
		#endregion
	}
}
