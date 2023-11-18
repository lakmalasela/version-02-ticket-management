namespace ticketissuesystem.Dtos.Item
{
    public class GetItemDto
    {


        public int Id { get; set; }
        public required string Itemname { get; set; }

        public required string Serialno { get; set; }

        public Branch branch { get; set; }

        public Itemtype Itemtype { get; set; }
    }
}
