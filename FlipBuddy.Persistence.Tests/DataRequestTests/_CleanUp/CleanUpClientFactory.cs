namespace FlipBuddy.Persistence.Tests.DataRequestTests._CleanUp
{
    public static class CleanUpClientFactory
    {
        public static async Task<CleanUpClient> GenerateNewCleanupClient() 
        {
            CleanUpClient client = new CleanUpClient(); 
            await Task.CompletedTask;
            return client;            
        }
    }
}
