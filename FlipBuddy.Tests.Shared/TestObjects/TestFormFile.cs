using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace FlipBuddy.Tests.Shared.TestObjects
{
    public  class TestFormFile
    {
        public static IFormFile CreateEmptyFormFile()
        {
            var stream = new MemoryStream(); // empty stream
            var formFile = new FormFile(stream, 0, 0, "Data", "empty.txt")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

            return formFile;
        }
    }
}
