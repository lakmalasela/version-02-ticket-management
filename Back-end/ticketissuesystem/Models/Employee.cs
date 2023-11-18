using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;

namespace ticketissuesystem.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        public required string Fullname { get; set; }

        [DataType(DataType.Date)]
        public required DateTime Dob { get; set; }

        [MaxLength(12), MinLength(10)]
        public required string Nic { get; set; }

        public required string Callingname { get; set; }

        public byte[]? Photo { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public required string Mobileno { get; set; }
     
        public required bool Gender { get; set; }

       
        public required Civilstatus Civilstatus { get; set; }
        //public required Civilstatus Civilstatus { get; set; }

        public required Designation Designation { get; set; }


        public required Branch Branch { get; set; }



    }
}
