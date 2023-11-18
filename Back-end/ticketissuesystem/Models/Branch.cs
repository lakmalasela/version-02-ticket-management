using System.Text.Json.Serialization;

namespace ticketissuesystem.Models
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Branch
    {
        Colombo = 1,
        Kandy = 2,
        Jaffna = 3
    }
}
