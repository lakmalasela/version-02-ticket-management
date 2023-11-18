using Microsoft.AspNetCore.Mvc;
using ticketissuesystem.Dtos.Employees;
using ticketissuesystem.Services.Employeeservice;

namespace ticketissuesystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }



        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> GetAll()
        {
            return Ok(await _employeeService.GetAllEmployee());

        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>>AddteEmployee(AddEmployeeDto addEmployee)
        {
            return  Ok(await _employeeService.AddEmployee(addEmployee));
        }



        [HttpGet("Getemployee/{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>>GetEmployee(int id)
        {
            return Ok(await _employeeService.GetEmployeeById(id));
        }


       [HttpPut("{id}")]
       public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> UpdatedEmployee(int id, UpdateEmplyeeDto updateEmplyee)
        {
            var response = await _employeeService.UpdateEmployee(id,updateEmplyee);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
           
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> DeleteEmployee(int id)
        {
            var response = await _employeeService.DeleteEmployee(id);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpGet("Civilstatus")]
        public async Task<ActionResult<ServiceResponse<String>>> GetCivilstatus()
        {
            var response = await _employeeService.GetEmployeestatus();
            if(response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }





        [HttpGet("branch")]
        public async Task<ActionResult<ServiceResponse<String>>> GetBranch()
        {
            var response = await _employeeService.GetEmployeebranch();
            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }




        [HttpGet("designation")]
        public async Task<ActionResult<ServiceResponse<String>>> GetDesignation()
        {
            var response = await _employeeService.GetEmployeedesignation();
            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }

}
