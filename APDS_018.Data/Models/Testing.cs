
namespace APDS_018.Data.Models
{
    public class Testing
    {
        public long Id { get; set; }
        public long RespondentId { get; set; }
        public long TestId { get; set; }
        public string TestingDate { get; set; } = string.Empty;
        public string TestingTime { get; set; } = string.Empty;
        public Respondent? Respondent { get; set; }
        public Test? Test { get; set; }
        public List<Protocol> Protocols { get; set; } = [];
        public List<Result> Results { get; set; } = [];
    }
}
