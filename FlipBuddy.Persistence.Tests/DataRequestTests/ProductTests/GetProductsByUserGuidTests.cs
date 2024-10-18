using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ProductTests
{
	public class GetProductsByUserGuidTests : BaseDataRequestTest
	{
		#region Happy Path
		[Fact]
		public async Task GetProductsByUserGuid_Given_UserExists_ShouldReturn_List()
		{
			var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

			var productGuid = Guid.NewGuid();

			await _dataAccess.ExecuteAsync(new InsertProduct(
												productGuid,
												user_DTO.Guid,
												TestString.Random(),
												TestNumber.GetSubTier(),
												DefaultValues.TestPurchasePrice,
												DefaultValues.TestPurchasePrice * 2,
												TestString.Random(),
												int.MinValue,
												TestString.Random(),
												TestNumber.GetConditionId(),
												TestString.Random(9)
											   ));


			var product = await _dataAccess.FetchListAsync(new GetProductsByUserGuid(user_DTO.Guid));

			await _dataAccess.ExecuteAsync(new DeleteProductByGuid(productGuid));
			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));

			Assert.Equal(1, product.Count());
		}
		#endregion

		#region Bad Paths
		[Fact]
		public async Task GetProductsByUserGuid_Given_UserDoesNotExist_ShouldReturnNull()
		{
			var rowsAffected = await _dataAccess.FetchListAsync(new GetProductsByUserGuid(Guid.NewGuid()));

			Assert.Empty(rowsAffected);
		}
		#endregion
	}
}
