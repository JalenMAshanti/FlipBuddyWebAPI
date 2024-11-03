using FlipBuddy.Domain.Constants;
using FlipBuddy.Persistence.Abstractions;
using System.Web;

namespace FlipBuddy.Persistence.DataRequestObjects.CleanUpRequests_TESTUSEONLY_
{
    public class DeleteUsersCleanUp : IDataExecute
    {
        public DeleteUsersCleanUp(string firstName) => Firstname = firstName; 

        public string Firstname { get; set; }
        
        public object? GetParameters() => this;

        public string GetSql() => $@"DELETE FROM {DatabaseTable.Users} WHERE FirstName = @Firstname";
    }
}
