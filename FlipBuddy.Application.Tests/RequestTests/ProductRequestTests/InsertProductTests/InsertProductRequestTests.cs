using FlipBuddy.Application.Requests.ProductRequests.Insert;
using FlipBuddy.Tests.Shared.TestObjects;

namespace FlipBuddy.Application.Tests.RequestTests.ProductRequestTests.InsertProductTests
{
	public class InsertProductRequestTests
	{
		#region Happy Path
		[Fact]
		public void InsertProductRequest_Given_RequestIsValid_IsValid_ShouldReturn_True()
		{
			var request = new InsertProductRequest(
													Guid.NewGuid(),
													Guid.NewGuid(),
													TestString.Random(),
													int.MinValue,
													int.MinValue,
													int.MinValue,
													TestString.Random(),
													int.MinValue,
													int.MinValue,
													TestString.Random(9)
												   );

			Assert.True(request.IsValid(out _));
		}
		#endregion

		#region Bad Paths
		[Fact]
		public void InsertProductRequest_Given_RequestIsEmpty_IsValid_ShouldReturn_True()
		{
			var request = new InsertProductRequest();

			Assert.False(request.IsValid(out _));
		}

		[Fact]
		public void InsertProductRequest_Given_EventGuidNotSet_IsValid_ShouldReturn_True()
		{
			var request = new InsertProductRequest(
													Guid.Empty,
													Guid.NewGuid(),
													TestString.Random(),
													int.MinValue,
													int.MinValue,
													int.MinValue,
													TestString.Random(),
													int.MinValue,
													int.MinValue,
													TestString.Random(9)
												   );

			Assert.False(request.IsValid(out _));
		}

		[Fact]
		public void InsertProductRequest_Given_UserGuidIsEmpty_IsValid_ShouldReturn_False()
		{
			var request = new InsertProductRequest(
													Guid.NewGuid(),
													Guid.Empty,
													TestString.Random(),
													int.MinValue,
													int.MinValue,
													int.MinValue,
													TestString.Random(),
													int.MinValue,
													int.MinValue,
													TestString.Random(9)
												   );

			Assert.False(request.IsValid(out _));
		}
		#endregion
	}
}
