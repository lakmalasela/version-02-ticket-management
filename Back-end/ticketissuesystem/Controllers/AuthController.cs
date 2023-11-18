using Microsoft.AspNetCore.Mvc;
using ticketissuesystem.Data;
using ticketissuesystem.Dtos.User;

namespace ticketissuesystem.Controllers
{

    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        public readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;

        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Reister(UserRegisterDto request)
        {
            var response = await _authRepo.Register(
        new User
        {
            Username = request.Username,
           Userstatus = request.Userstatus


        },
        request.Password,
        request.Userstatus,
        request.Designation

    // Include the employee parameter here
    );

            if (!response.Sucess)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }


        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login([FromBody] UserLoginDto request)
        {

            var response = await _authRepo.Login(request.Username, request.Password);

            if (!response.Sucess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
