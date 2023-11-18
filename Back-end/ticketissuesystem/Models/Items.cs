using System.ComponentModel.DataAnnotations;

namespace ticketissuesystem.Models
{
    public class Items
    {

        public int Id { get; set; }
        public required string Itemname { get; set; }

        public required string Serialno { get; set; }

       public Branch    Branch { get; set; }

        public Itemtype Itemtype { get; set; }

        public List<Inventory>?  Inventories { get; set; }

    }
}
