using System.Text.Json.Serialization;

namespace ticketissuesystem.Models
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Designation
    {
        Manager = 1,
        Supervisor = 2,
        Technician = 3,
       
    }
}
