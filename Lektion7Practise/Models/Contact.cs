using MongoDB.Bson;

namespace Lektion7Practise.Models
{
    public class Contact
    {
        public ObjectId Id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string emaila { get; set; }
        public string country { get; set; }
    }
}
