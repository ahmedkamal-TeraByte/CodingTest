using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingTest.Models
{
    public class AudioBook : IAudio
    {
        public AudioBook()
        {

        }
        public AudioBook(Dictionary<string, object> metadata)
        {
            Parse(metadata);
        }

        [Required]
        [Key]
        public int ID { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(100)]
        public string Author { get; set; }
        [Required, StringLength(100)]
        public string Narrator { get; set; }
        [Required]
        public uint Duration { get; set; }
        [Required]
        public DateTime UploadTime { get; set; }

        public bool CheckMetaData(Dictionary<string, object> metaData)
        {
            if (metaData.ContainsKey("Duration") && metaData.ContainsKey("Title") && metaData.ContainsKey("Author") && metaData.ContainsKey("Narrator") && metaData.ContainsKey("UploadTime"))
                return true;
            return false;
        }

        public void Parse(Dictionary<string, object> metaData)
        {
            if (CheckMetaData(metaData))
            {
                ID = Convert.ToInt32(metaData["ID"]?.ToString());
                Title = metaData["Title"].ToString();
                Duration = Convert.ToUInt32(metaData["Duration"].ToString());
                UploadTime = Convert.ToDateTime(metaData["UploadTime"].ToString());
                Narrator = metaData["Narrator"].ToString();
                Author = metaData["Author"].ToString();

            }
            if (!Validate())
                throw new Exception("Data is invalid");
        }

        public bool Validate()
        {
            if (Title.Length > 100 || UploadTime < DateTime.Now || Duration == 0 || Author.Length > 100 || Narrator.Length > 100)
                return false;
            return true;
        }

    }
}
