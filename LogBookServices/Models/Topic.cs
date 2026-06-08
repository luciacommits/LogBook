using System.ComponentModel.DataAnnotations;

namespace LogBook.Models
{
    public class Topic
    {
        [Key]
        public int TopicID { get; set; }
        public string? Theme { get; set; }
        public string? Content { get; set; }
    }
}
