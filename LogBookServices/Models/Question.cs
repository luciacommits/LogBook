using System.ComponentModel.DataAnnotations;

namespace LogBook.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public string? QuestionStatement { get; set; }
        public int QuestionDate { get; set; }
        public int AnswerDate{ get; set; }
        public string? Answer { get; set; }
    }
}
