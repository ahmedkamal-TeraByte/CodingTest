using System.Collections.Generic;

namespace CodingTest.Controllers
{
    public class CreateRequest
    {
        public string AudioFileType { get; set; }
        public Dictionary<string, object> Metadata { get; set; }

        //public bool Validate()
        //{

        //}
    }
}