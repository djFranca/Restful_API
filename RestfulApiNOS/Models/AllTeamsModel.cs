using Newtonsoft.Json;

namespace RestfulApiNOS.Models
{
    public class AllTeamsModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("TeamName")]
        public string TeamName { get; set; }
    }
}
