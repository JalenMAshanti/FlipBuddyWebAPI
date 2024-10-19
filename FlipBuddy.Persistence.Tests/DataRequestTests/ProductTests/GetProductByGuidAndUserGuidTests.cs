using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ProductTests
{
	public class GetProductByGuidAndUserGuidTests : BaseDataRequestTest
	{
		#region Happy Path
		[Fact]
		public async Task GetProductsByGuidandUserGuid_Given_GuidsExist_ShouldReturn_NotNull()
		{
			var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

			var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);


			var product = await _dataAccess.FetchAsync(new GetProductByGuidAndUserGuid(user_DTO.Guid, product_DTO.Guid));

			await _dataAccess.ExecuteAsync(new DeleteProductByGuid(product_DTO.Guid));
			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));

			Assert.NotNull(product);
		}
		#endregion

		#region Bad Paths

		[Fact]
		public async Task GetProductsByGuidandUserGuid_Given_UserGuidDoesNotExist_ShouldReturn_Null()
		{
			var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

			var product_DTO = await TestProduct.InsertAndFetchProductDtoAsync(user_DTO.Guid);

			var products = await _dataAccess.FetchAsync(new GetProductByGuidAndUserGuid(Guid.NewGuid(), product_DTO.Guid));

			Assert.Null(products);
		}


		[Fact]
		public async Task GetProductsByGuidandUserGuid_Given_GuidDoesNotExist_ShouldReturn_Null()
		{
			var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

			var products = await _dataAccess.FetchAsync(new GetProductByGuidAndUserGuid(user_DTO.Guid, Guid.NewGuid()));

			Assert.Null(products);
		}


		[Fact]
		public async Task GetProductsByGuidandUserGuid_Given_GuidsDoNotExist_ShouldReturn_Null()
		{
			var products = await _dataAccess.FetchAsync(new GetProductByGuidAndUserGuid(Guid.NewGuid(), Guid.NewGuid()));

			Assert.Null(products);
		}
		#endregion
	}
}
