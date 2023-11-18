using System.ComponentModel.DataAnnotations;

namespace ticketissuesystem.Models
{
    public class Ticketissue
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public required DateTime Dob { get; set; }

       public required string Ticketno { get; set; }



    }


}
