using System.Collections.Generic;

namespace CodingTest.Models
{
    interface IAudio
    {
        public int ID { get; set; }
        public void Parse(Dictionary<string, object> metaData);
        public bool Validate();
        public bool CheckMetaData(Dictionary<string, object> metaData);
    }
}
