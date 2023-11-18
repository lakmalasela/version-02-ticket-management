using System.Text.Json.Serialization;

namespace ticketissuesystem.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Civilstatus
    {
        Single = 1,
        Married = 2
    }
}
