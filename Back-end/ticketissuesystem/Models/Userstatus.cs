using System.Text.Json.Serialization;

namespace ticketissuesystem.Models
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Userstatus
    {

        Active = 1,
        Deleted = 2
    }
}
