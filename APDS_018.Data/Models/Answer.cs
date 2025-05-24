
namespace APDS_018.Data.Models
{
    public class Answer
    {
        public long Id { get; set; }
        public long TestId { get; set; }
        public long NumQuestion { get; set; }
        public long NumAnswer { get; set; }
        public string AnswerText {  get; set; } = string.Empty;
        public Test? Test { get; set; }
        public Question? Question { get; set; }
        public List<Protocol> Protocols { get; set; } = [];
    }
}
