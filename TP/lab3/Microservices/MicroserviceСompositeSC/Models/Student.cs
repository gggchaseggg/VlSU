using System.Text.Json.Serialization;

namespace MicroserviceCompositeSC.Models
{
    public class Student
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("surname")]
        public string Surname { get; set; }
        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }
        [JsonPropertyName("groupName")]
        public string GroupName { get; set; }
        [JsonPropertyName("score")]
        public int Score { get; set; }
        [JsonPropertyName("placeInRanking")]
        public int PlaceInRanking { get; set; }
        [JsonPropertyName("speciality")]
        public string Speciality { get; set; }
    }
}