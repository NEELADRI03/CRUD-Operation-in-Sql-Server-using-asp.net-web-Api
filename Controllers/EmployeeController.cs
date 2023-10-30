using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlApiDemo.Entities;
using SqlApiDemo.Models;
using SqlApiDemo.Services;

namespace SqlApiDemo.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public  readonly IEmployeeRepo _employeeRepo;
        public readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        [HttpPost("/CreateEmployee")]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployee(EmployeeDTO employee)
        {
            var employeeEntity=_mapper.Map<Employee>(employee);  
            _employeeRepo.AddEmployee(employeeEntity);

            await _employeeRepo.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDTO>(employeeEntity);

            return Ok(employeeToReturn);
        }

        [HttpGet("/GetEmployees")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            
            var authorsFromRepo = await _employeeRepo.GetEmployees();

          
            return Ok(_mapper.Map<IEnumerable<EmployeeDTO>>(authorsFromRepo));
        }

        [HttpGet("/GetEmployee")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int Id)
        {
            
            var empFromRepo = await _employeeRepo.GetEmployee(Id);

            if (empFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EmployeeDTO>(empFromRepo));
        }

        [HttpPut("/Update")]
        public async Task<ActionResult<EmployeeDTO>> UpdateEmployee(EmployeeDTO employee)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);
            _employeeRepo.UpdateEmployee(employeeEntity);

            await _employeeRepo.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDTO>(employeeEntity);

            return Ok(employeeToReturn);
        }

        [HttpDelete("/Delete")]
        public string DeleteEmployee(int Id) 
        { 
            return _employeeRepo.DeleteEmployee(Id);
            
        }
    }
}
