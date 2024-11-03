namespace FlipBuddy.Persistence.Tests.DataRequestTests._CleanUp
{
    public class CleanUpClient
    {
        public async Task CleanUpDB()
        {
            TestCleanUpRequest cleanUpRequest = new TestCleanUpRequest();
            await cleanUpRequest.CleanUp();
        }
    }
}
