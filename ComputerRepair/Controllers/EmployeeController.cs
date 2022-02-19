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

        [HttpPost]
        public async Task Post(EmployeeDto employeeDto)
        {
            var entity = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.Post(entity);
        }

        [HttpGet]
        public async Task<List<EmployeeDto>> GetAll()
        {
            var enteties = await _employeeRepository.GetAll();
            var dto = _mapper.Map<List<EmployeeDto>>(enteties);
            return dto;
        }

        [HttpPost("employees/{eId}/computers/{cId}")]
        public async Task AssignComputerToEmployee(int eId, int cId)
        {
            var employeeEntity = _employeeRepository.FindEmployeeById(eId);

            var ComputerEmployee = _computerRepository.FindComputerById(cId);

            employeeEntity.Computers.Add(ComputerEmployee);

            await _employeeRepository.Update(employeeEntity);



        }
    }
}
