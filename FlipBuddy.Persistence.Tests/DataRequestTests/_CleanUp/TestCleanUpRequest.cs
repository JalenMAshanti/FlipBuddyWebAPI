using FlipBuddy.Persistence.DataRequestObjects.CleanUpRequests_TESTUSEONLY_;
using FlipBuddy.Tests.Shared.Constants;

namespace FlipBuddy.Persistence.Tests.DataRequestTests._CleanUp
{
    public class TestCleanUpRequest : BaseDataRequestTest
    {
        public async Task CleanUp() 
        {    
              await _dataAccess.ExecuteAsync(new DeleteProductCleanUp(TestValues.ProductTitle));

              await _dataAccess.ExecuteAsync(new DeleteUsersCleanUp(TestValues.UserFirstName));
        }
    }
}
