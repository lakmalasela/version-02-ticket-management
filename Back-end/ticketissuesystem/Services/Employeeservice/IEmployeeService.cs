
using ticketissuesystem.Models;

namespace ticketissuesystem.Services.Employeeservice
{
    public interface IEmployeeService
    {

        Task<ServiceResponse <List<GetEmployeeDto>>> GetAllEmployee();
        Task<ServiceResponse <GetEmployeeDto>> GetEmployeeById(int id);

        Task<ServiceResponse<GetEmployeeDto>> UpdateEmployee(int id, UpdateEmplyeeDto updateEmplyee);

        Task<ServiceResponse<List<GetEmployeeDto>>>AddEmployee(AddEmployeeDto Employee);

        Task<ServiceResponse<List<GetEmployeeDto>>> DeleteEmployee(int id);

        Task<ServiceResponse<List<String>>> GetEmployeestatus();

        Task<ServiceResponse<List<String>>> GetEmployeebranch();

        Task<ServiceResponse<List<String>>> GetEmployeedesignation();

    }
}
