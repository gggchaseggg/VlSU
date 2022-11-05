using System.Text.Json.Serialization;

namespace MicroserviceCompositeSC.Models
{
    public class Student
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("groupName")]
        public string GroupName { get; set; }
        [JsonPropertyName("rating")]
        public int Rating { get; set; }
    }
}