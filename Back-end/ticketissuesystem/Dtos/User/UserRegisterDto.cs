namespace ticketissuesystem.Dtos.User
{
    public class UserRegisterDto
    {

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public required Userstatus Userstatus { get; set; }

        public Designation Designation { get; set; } = Designation.Technician;
    }
}
