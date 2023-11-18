using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ticketissuesystem.Data
{
    public class AuthRepository : IAuthRepository
    {

        public readonly DataContext _context;
        public readonly IConfiguration _configuration;
        public AuthRepository(DataContext context, IConfiguration configuration) //IConfiguration app setting json file eka access krnna denwa
        {
            _configuration = configuration;
            _context = context;
            // _context = context;

        }
        public async Task<ServiceResponse<string>> Login(string usernme, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username.ToLower().Equals(usernme.ToLower())); //username eka check krnwa

            if (user is null)
            {
                response.Sucess = false;
                response.Message = "User not foud";

            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            { //filter krla gnna user gen PasswordHash,PasswordSalt ekai gnnwa
                response.Sucess = false;
                response.Message = "Password Wrong";
            }
            else
            {
                response.Data = CreateTocken(user);
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password, Userstatus userstatus,Designation designation)
        {
            var response = new ServiceResponse<int>();

         

            //input krna user exist user kenek da kiyla blnwa
            if (await UserExists(user.Username))
            {
                response.Sucess = false;
                response.Message = "User Already Exists";
            }
            //password has krna function eka call krnwa
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            
            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
            {
                return true;
            }

            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            { //instance ekak hadaa gththa key eka generate krnna
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }



        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHas = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHas.SequenceEqual(passwordHash);
            }
        }

        private string CreateTocken(User user)
        {

            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username.ToString())

            };
            var appSettingsTocken = _configuration.GetSection("AppSettings:Tocken").Value; //appseting file ekee hadaa gththa plain text eka thamq methana tocken ekak wedihata hadanne
            if (appSettingsTocken is null)
            {
                throw new Exception("AppSetting Tocken is null");
            }
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(appSettingsTocken));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            //final tocken

            var tockenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1), //after oneday is expire
                SigningCredentials = creds

            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tockenDescriptor);
            return tokenHandler.WriteToken(token); //JSON token ekak wedihata covnert krnwa
        }



    }
}
