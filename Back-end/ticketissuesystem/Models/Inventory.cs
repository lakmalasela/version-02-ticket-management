using System.ComponentModel.DataAnnotations.Schema;

namespace ticketissuesystem.Models
{
    public class Inventory
    {


        public int Id { get; set; }





        public required  Items Items { get; set; }

        public Inventorystatus Inventorystatus { get; set; } = Inventorystatus.Avilable;



    }
}
