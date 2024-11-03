using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;

namespace FlipBuddy.Persistence.DataRequestObjects.CleanUpRequests_TESTUSEONLY_
{
    public class DeleteProductCleanUp : IDataExecute
    {
        public DeleteProductCleanUp(string title) => Title = title;
        
        public string Title { get; set; }

        public object? GetParameters() => this;

        public string GetSql() => $@"DELETE FROM {DatabaseTable.Products} WHERE Title = @Title";
    }
}
