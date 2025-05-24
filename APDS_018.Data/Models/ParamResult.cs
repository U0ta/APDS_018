

namespace APDS_018.Data.Models
{
    public class ParamResult
    {
        public long Id { get; set; }
        public long TestId { get; set; }
        public string Parametr { get; set; } = string.Empty;
        public string MinValue { get; set; } = string.Empty;
        public string MaxValue { get; set; } = string.Empty;
        public Test? Test { get; set; }
        public List<Result> Results { get; set; } = [];
    }
}
