
namespace APDS_018.Data.Models
{
    public class Protocol
    {
        public long Id { get; set; }
        public long TestingId { get; set; }
        public long NumAnswer { get; set; }
        public long NumQuestion {  get; set; }
        public DateTime TimeAnswer { get; set; }
        public string AnswerText { get; set; } = string.Empty;
        public Testing? Testing { get; set; }
        public Question? Question { get; set; }
        public Answer? Answer { get; set; }

    }
}
