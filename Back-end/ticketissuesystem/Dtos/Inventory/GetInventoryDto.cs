using System.ComponentModel.DataAnnotations.Schema;

namespace ticketissuesystem.Dtos.Inventory
{
    public class GetInventoryDto
    {


        public int Id { get; set; }

     
        public int ItemsId { get; set; }


        public required Inventorystatus Inventorystatus { get; set; }
    }
}
