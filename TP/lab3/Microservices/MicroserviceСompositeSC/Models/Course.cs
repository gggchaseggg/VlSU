using System.Text.Json.Serialization;

namespace MicroserviceCompositeSC.Models
{
    public class Course
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("disciplenes")]
        public string Disciplenes { get; set; }
        [JsonPropertyName("departament")]
        public string Departament { get; set; }
    }
}

