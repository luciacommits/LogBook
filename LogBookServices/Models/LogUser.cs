using System.ComponentModel.DataAnnotations;

namespace LogBook.Models
{
    public class LogUser
    {
        [Key]
        public int UserID { get; set; }
        public string? Email { get; set; }

        public string? UserName { get; set; }
    }
}
