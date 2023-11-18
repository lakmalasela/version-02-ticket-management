

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ticketissuesystem.Data;
using ticketissuesystem.Models;


namespace ticketissuesystem.Services.Employeeservice
{
    public class EmployeeService : IEmployeeService
    {

        public readonly IMapper _mapper;

        public readonly DataContext _context;
        public EmployeeService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        private static List<Employee> employees = new List<Employee> {



            /*new Employee{ Id = 1,
                Callingname ="Lakmal",
                Fullname ="Lakmal Asela",
                Nic = "952852302V",
                Mobileno = "0756273298",
                 Dob = new DateTime(1995, 10, 11),
                 Gender = true
            }
            */
        };

       

        public async Task<ServiceResponse<List<GetEmployeeDto>>> GetAllEmployee()
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeDto>>();
            var dbEmployee = await _context.Employees.ToListAsync();
            serviceResponse.Data =  dbEmployee.Select(c => _mapper.Map<GetEmployeeDto>(c)).ToList();

            return serviceResponse;


        }

        public async Task<ServiceResponse<GetEmployeeDto>> GetEmployeeById(int id)
        {
            var serviceResponse = new ServiceResponse<GetEmployeeDto>();
           var dbEmployee = await _context.Employees.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetEmployeeDto> (dbEmployee);

            return serviceResponse;


        }

        

        public async Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto newEmployee)
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeDto>>();
            
            var employee = _mapper.Map<Employee>(newEmployee);

            //employee.Id = employees.Max(c => c.Id)+1;
            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Employees.Select(c => _mapper.Map<GetEmployeeDto>(c)).ToListAsync();

            //employees.Add(employee);
           // serviceResponse.Data = employees.Select(c => _mapper.Map<GetEmployeeDto>(c)).ToList();
            return serviceResponse;
        }

       

        public async Task<ServiceResponse<GetEmployeeDto>> UpdateEmployee(int id,UpdateEmplyeeDto updateEmplyee)
        {
            var serviceResponse = new ServiceResponse<GetEmployeeDto>();

            try
            {
                var employee = 
                    
                  await  _context.Employees.FirstOrDefaultAsync(c => c.Id == id);
                if (employee is null)
                {
                    throw new Exception($"Employee with Id '{updateEmplyee.Id}'Not found");
                }


                employee.Fullname = updateEmplyee.Fullname;
                employee.Nic = updateEmplyee.Nic;
                employee.Callingname = updateEmplyee.Callingname;
                employee.Dob = updateEmplyee.Dob;
                employee.Mobileno = updateEmplyee.Mobileno;
                employee.Gender = updateEmplyee.Gender;
                employee.Civilstatus = updateEmplyee.Civilstatus;
                employee.Designation = updateEmplyee.Designation;
                employee.Branch = updateEmplyee.Branch;


  //              employee.Civilstatus = _mapper.Map<Civ>(updateEmplyee.Civilstatus);


                if (employee.Photo is not null)
                {
                    employee.Photo = updateEmplyee.Photo;
                }

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetEmployeeDto>(employee);

            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetEmployeeDto>>> DeleteEmployee(int id)
        {
            var serviceResponse = new ServiceResponse<List< GetEmployeeDto>>();
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(c => c.Id == id);
                if (employee is null)
                    throw new Exception($"Character with Id '{id}'Not found");

                _context.Employees.Remove(employee);

                await _context.SaveChangesAsync();


                //employees.Remove(employee);
                serviceResponse.Data = await _context.Employees.Select(c => _mapper.Map<GetEmployeeDto>(c)).ToListAsync();


            }catch(Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<string>>> GetEmployeestatus()
        {
            var serviceResponse = new ServiceResponse<List<String>>();

            try
            {
                var enumType = typeof(Civilstatus);
                if (enumType.IsEnum)
                {
                    var enumValues = Enum.GetNames(enumType).ToList();
                    serviceResponse.Data = enumValues;
                    serviceResponse.Sucess = true;
                }
                else
                {
                    serviceResponse.Message = "The provided type is not an enum.";
                    serviceResponse.Sucess = false;
                }
               
            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error: {ex.Message}";
                serviceResponse.Sucess = false;
            }


            return await Task.FromResult(serviceResponse);
            
        }

        public async Task<ServiceResponse<List<string>>> GetEmployeebranch()
        {
            var serviceResponse = new ServiceResponse<List<String>>();

            try
            {
                var enumType = typeof(Branch);
                if (enumType.IsEnum)
                {
                    var enumValues = Enum.GetNames(enumType).ToList();
                    serviceResponse.Data = enumValues;
                    serviceResponse.Sucess = true;
                }
                else
                {
                    serviceResponse.Message = "The provided type is not an enum.";
                    serviceResponse.Sucess = false;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error: {ex.Message}";
                serviceResponse.Sucess = false;
            }


            return await Task.FromResult(serviceResponse); 
        }

        public async Task<ServiceResponse<List<string>>> GetEmployeedesignation()
        {
            var serviceResponse = new ServiceResponse<List<String>>();

            try
            {
                var enumType = typeof(Designation);
                if (enumType.IsEnum)
                {
                    var enumValues = Enum.GetNames(enumType).ToList();
                    serviceResponse.Data = enumValues;
                    serviceResponse.Sucess = true;
                }
                else
                {
                    serviceResponse.Message = "The provided type is not an enum.";
                    serviceResponse.Sucess = false;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error: {ex.Message}";
                serviceResponse.Sucess = false;
            }


            return await Task.FromResult(serviceResponse);
        }
    }
}
