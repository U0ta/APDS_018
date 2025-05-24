
namespace APDS_018.Data.Models
{
    public class Test
    {
        public long Id { get; set; }
        public string NameTest { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string RunFile { get; set; } = string.Empty;
        public string Instruction { get; set; } = string.Empty;
        public string Help { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public string Psycologist { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public List<Question> Questions { get; set; } = [];
        public List<Answer> Answers { get; set; } = [];
        public List<ParamResult> ParamResults { get; set; } = [];
        public List<Testing> Testings { get; set; } = [];
    }
}
