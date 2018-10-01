
using Newtonsoft.Json;

namespace RestfulApiNOS.Models
{
    public class UpdateTeamInfoModel
    {
        [JsonProperty("TeamCoach")]
        public string TeamCoach { get; set; }
        [JsonProperty("TeamGames")]
        public int TeamGames { get; set; }
        [JsonProperty("TeamScore")]
        public int TeamScore { get; set; }
        [JsonProperty("TeamRanking")]
        public int TeamRanking { get; set; }
    }
}
