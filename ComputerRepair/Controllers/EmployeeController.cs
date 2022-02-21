using AutoMapper;
using ComputerRepair.Data;
using ComputerRepair.Dtos;
using ComputerRepair.Enteties;
using ComputerRepair.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ComputerRepair.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly ComputerRepository _computerRepository;
        private readonly IMapper _mapper;

        public EmployeeController(EmployeeRepository employeeRepository, ComputerRepository computerRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _computerRepository = computerRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<List<EmployeeDto>> GetAll()
        {
            var enteties = await _employeeRepository.GetAll();
            var dto = _mapper.Map<List<EmployeeDto>>(enteties);
            return dto;
        }

         [HttpGet("sortbylastname")]
         public  async Task<List<EmployeeDto>> GetAllByLastName()
        {
            var entities = await _employeeRepository.GetSortByLastName();
            var dto = _mapper.Map<List<EmployeeDto>>(entities);
            return dto;
        }

        [HttpGet("dto")]
        public async Task<List<EmployeeGetDto>> GetAllDto()
        {
            // var dto = _mapper.Map<List<EmployeeGetDto>>(enteties);
            return await _employeeRepository.GetAllDto();
        }

        [HttpGet("employees/maintenance")] 
        public async Task<List<EmployeeMaintenanceDto>> GetEmployeeMaintenance()
        {
            return await _employeeRepository.GetEmployeeMaintenance();
        }

        [HttpPost]
        public async Task Post(EmployeeDto employeeDto)
        {
            var entity = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.Post(entity);
        }

        [HttpPost("employees/{eId}/computers/{cId}")]
        public async Task AssignComputerToEmployee(int eId, int cId)
        {
            var employeeEntity = _employeeRepository.FindEmployeeById(eId);

            var ComputerEmployee = _computerRepository.FindComputerById(cId);

            employeeEntity.Computers.Add(ComputerEmployee);

            await _employeeRepository.Update(employeeEntity);
        }

        [HttpPut]
        public async Task Update(EmployeeDto employeeDto)
        {
            var entity = _mapper.Map<Employee>(employeeDto);

            await _employeeRepository.Update(entity);
        }

        [HttpDelete("{id}")]

        public async Task Delete(int id)
        {
            await _employeeRepository.Delete(id);
        }

    }
}
