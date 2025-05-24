
namespace APDS_018.Data.Models
{
    public class Result
    {
        public long Id { get; set; }
        public long ParamResultId { get; set; }
        public long TestingId { get; set; }
        public string ValueResult { get; set; } = string.Empty;
        public Testing? Testing { get; set; }
        public ParamResult? ParamResult { get; set; }
    }
}
