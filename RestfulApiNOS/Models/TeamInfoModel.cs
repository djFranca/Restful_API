using Newtonsoft.Json;

namespace RestfulApiNOS.Models
{
    public class TeamInfoModel
    {
        [JsonProperty("TeamId")]
        public int TeamId { get; set; }
        [JsonProperty("TeamName")]
        public string TeamName { get; set; }
        [JsonProperty("TeamCoach")]
        public string TeamCoach { get; set; }
        [JsonProperty("TeamStadium")]
        public string TeamStadium { get; set; }
        [JsonProperty("TeamGames")]
        public int TeamGames { get; set; }
        [JsonProperty("TeamWons")]
        public int TeamWons { get; set; }
        [JsonProperty("TeamDraws")]
        public int TeamDraws { get; set; }
        [JsonProperty("TeamLosts")]
        public int TeamLosts { get; set; }
        [JsonProperty("TeamScore")]
        public int TeamScore { get; set; }
        [JsonProperty("TeamRanking")]
        public int TeamRanking { get; set; }
    }
}
