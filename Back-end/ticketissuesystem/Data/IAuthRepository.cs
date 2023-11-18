namespace ticketissuesystem.Data
{
    public interface IAuthRepository
    {

        Task<ServiceResponse<int>> Register(User user, string password,Userstatus userstatus,Designation designation);

        Task<ServiceResponse<string>> Login(string usernme, string password);//for login

        Task<bool> UserExists(string username);
    }
}
