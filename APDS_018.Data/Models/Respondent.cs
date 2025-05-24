

namespace APDS_018.Data.Models
{
    public class Respondent
    {
        public long Id { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string NameResp { get; set; } = string.Empty;
        public string Midlename { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public DateTime Born { get; set; }
        public List<Testing> Testings { get; set; } = [];
    }
}
