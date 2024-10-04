using FlipBuddy.Domain.Exceptions;
using FlipBuddy.Persistence.DataRequestObjects.ProductRequests;
using FlipBuddy.Persistence.DataRequestObjects.UserRequests;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.ProductTests
{
	public class InsertProductTests : BaseDataRequestTest
	{
		#region Happy Path
		[Fact]
		public async Task InsertProduct_Given_InputIsValid_ShouldReturnOneRowAffected()
		{
			var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

			var productGuid = Guid.NewGuid();

			var insertProductRequest = new InsertProduct(
														productGuid,
														user_DTO.Guid,
														TestString.Random(),
														TestNumber.GetSubTier(),
														int.MinValue,
														int.MinValue,
														TestString.Random(),
														int.MinValue,
														TestString.Random(),
														TestNumber.GetConditionId(),
														TestString.Random(9)
														);

			var rowsAffected = await _dataAccess.ExecuteAsync(insertProductRequest);

			await _dataAccess.ExecuteAsync(new DeleteProductByGuid(productGuid));
			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));

			Assert.Equal(1, rowsAffected);
		}
		#endregion

		#region Bad Paths
		[Fact]
		public async Task InsertProduct_Given_GuidAlreadyTacked_ShouldThrowDataAccessException()
		{
			var user_DTO = await TestUser.InsertAndFetchUsersDtoAsync();

			var productGuid = Guid.NewGuid();

			var insertProductRequest = new InsertProduct(
														productGuid,
														user_DTO.Guid,
														TestString.Random(),
														TestNumber.GetSubTier(),
														int.MinValue,
														int.MinValue,
														TestString.Random(),
														int.MinValue,
														TestString.Random(),
														TestNumber.GetConditionId(),
														TestString.Random(9)
														);

			var insertProductRequestSameGuid = new InsertProduct(
														productGuid,
														user_DTO.Guid,
														TestString.Random(),
														TestNumber.GetSubTier(),
														int.MinValue,
														int.MinValue,
														TestString.Random(),
														int.MinValue,
														TestString.Random(),
														TestNumber.GetConditionId(),
														TestString.Random(9)
														);

			await _dataAccess.ExecuteAsync(insertProductRequest);

			var exception = await Record.ExceptionAsync(async () => await _dataAccess.ExecuteAsync(insertProductRequestSameGuid));

			Assert.IsType<DataAccessException>(exception);

			await _dataAccess.ExecuteAsync(new DeleteProductByGuid(productGuid));
			await _dataAccess.ExecuteAsync(new DeleteUserByGuid(user_DTO.Guid));
		}
		#endregion
	}
}
