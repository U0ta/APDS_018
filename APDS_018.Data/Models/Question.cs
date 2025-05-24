

namespace APDS_018.Data.Models
{
    public class Question
    {
        public long Id { get; set; }
        public long TestId { get; set; }
        public long NumQuestion { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string QuestionType { get; set; } = string.Empty;
        public string QuestionFile { get; set; } = string.Empty;
        public Test? Test { get; set; }
        public List<Answer> Answers { get; set; } = [];
        public List<Protocol> Protocols { get; set; } = [];
    }
}
