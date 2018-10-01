using Newtonsoft.Json;

namespace RestfulApiNOS.Models
{
    public class EspecificTeamModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Player")]
        public string Player { get; set; }
        [JsonProperty("Age")]
        public int Age { get; set; }
        [JsonProperty("Country")]
        public string Country { get; set; }
        [JsonProperty("Position")]
        public string Position { get; set; }
    }
}
