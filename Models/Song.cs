using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingTest.Models
{
    public class Song : IAudio
    {
        public Song()
        {

        }
        public Song(Dictionary<string, object> metadata)
        {
            Parse(metadata);
        }
        [Required]
        [Key]
        public int ID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required]
        public uint Duration { get; set; }
        [Required]
        public DateTime UploadTime { get; set; }
        public void Parse(Dictionary<string, object> metaData)
        {
            if (CheckMetaData(metaData))
            {
                ID = Convert.ToInt32(metaData["ID"]?.ToString());
                Name = metaData["Name"].ToString();
                Duration = Convert.ToUInt32(metaData["Duration"].ToString());
                UploadTime = Convert.ToDateTime(metaData["UploadTime"].ToString());
                if (!Validate())
                    throw new Exception("Data is invalid");
            }
            else
                throw new Exception("Please provide complete data for song.");

        }

        public bool Validate()
        {
            if (Name.Length > 100 || UploadTime < DateTime.Now || Duration == 0)
                return false;
            return true;
        }
        public bool CheckMetaData(Dictionary<string, object> metaData)
        {
            if (metaData.ContainsKey("Duration") && metaData.ContainsKey("Name") && metaData.ContainsKey("UploadTime"))
                return true;
            return false;
        }
    }
}
