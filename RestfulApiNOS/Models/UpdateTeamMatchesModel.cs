using Newtonsoft.Json;

namespace RestfulApiNOS.Models
{
    public class UpdateTeamMatchesModel
    {
        [JsonProperty("TeamWons")]
        public int TeamWons { get; set; }
        [JsonProperty("TeamDraws")]
        public int TeamDraws { get; set; }
        [JsonProperty("TeamLosts")]
        public int TeamLosts { get; set; }
    }
}
