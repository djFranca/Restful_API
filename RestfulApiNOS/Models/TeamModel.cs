
using Newtonsoft.Json;

namespace RestfulApiNOS.Models
{
    public class TeamInfo
    {
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Coach")]
        public string Coach { get; set; }
        [JsonProperty("Stadium")]
        public string Stadium { get; set; }
    }
}