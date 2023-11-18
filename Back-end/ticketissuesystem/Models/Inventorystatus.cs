using System.Text.Json.Serialization;

namespace ticketissuesystem.Models
{


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Inventorystatus
    {


        Avilable = 1,
        NotAvailable = 2
    }
}
