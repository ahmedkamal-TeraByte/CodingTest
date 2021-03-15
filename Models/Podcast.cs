using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingTest.Models
{
    public class Podcast : IAudio
    {
        public Podcast()
        {

        }
        public Podcast(Dictionary<string, object> metadata)
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
        [Required, StringLength(100)]
        public string Host { get; set; }
        [Required, StringLength(1200)]
        public string Participants { get; set; }
        [NotMapped]
        public List<string> ParticipantList
        {
            get
            {
                var list = Participants.Split(',');
                return new List<string>(list);
            }
        }

        public bool CheckMetaData(Dictionary<string, object> metaData)
        {
            if (metaData.ContainsKey("Duration") && metaData.ContainsKey("Name") && metaData.ContainsKey("UploadTime") && metaData.ContainsKey("host") && metaData.ContainsKey("Participants"))
                return true;
            return false;
        }

        public void Parse(Dictionary<string, object> metaData)
        {
            if (CheckMetaData(metaData))
            {
                Name = metaData["Name"].ToString();
                Duration = Convert.ToUInt32(metaData["Duration"].ToString());
                UploadTime = Convert.ToDateTime(metaData["UploadTime"].ToString());
                Host = metaData["Host"].ToString();
                Participants = metaData["Participants"].ToString();
            }
            if (!Validate())
                throw new Exception("Data is invalid");
        }

        public bool Validate()
        {
            if (Name.Length > 100 || UploadTime < DateTime.Now || Duration == 0 || Host.Length > 100 || ParticipantList.Count > 10)
                return false;
            foreach (var participant in ParticipantList)
            {
                if (participant.Length > 100)
                    return false;
            }
            return true;
        }
    }
}
