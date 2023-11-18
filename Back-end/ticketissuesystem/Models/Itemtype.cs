using System.Text.Json.Serialization;

namespace ticketissuesystem.Models
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Itemtype
    {
        software = 1,
        hardware = 2,
        netwok = 3



    }
}
