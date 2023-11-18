namespace ticketissuesystem.Dtos.Inventory
{
    public class AddInventoryDto
    {


        public int Id { get; set; }
        public required Items Item { get; set; }

        public required Inventorystatus Inventorystatus { get; set; }
    }
}
