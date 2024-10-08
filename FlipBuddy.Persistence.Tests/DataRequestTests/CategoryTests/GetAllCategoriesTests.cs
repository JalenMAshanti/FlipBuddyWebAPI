using FlipBuddy.Persistence.DataRequestObjects.CategoryRequests;

namespace FlipBuddy.Persistence.Tests.DataRequestTests.CategoryTests
{
	public class GetAllCategoriesTests : BaseDataRequestTest
	{
		#region Happy Path
		[Fact]
		public async Task GetAllCategories_ShouldReturn_NotNull()
		{
			var rowAffected = await _dataAccess.FetchAsync(new GetAllCategories());

			Assert.NotNull(rowAffected);
		}
		#endregion
	}
}
