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
        private readonly EmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeController(EmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task Post(EmployeeDto employeeDto)
        {
            var entity = _mapper.Map<Employee>(employeeDto);
            await _repository.Post(entity);
        }

        [HttpGet]
        public async Task<List<EmployeeDto>> GetAll()
        {
            var enteties = await _repository.GetAll();
            var dto = _mapper.Map<List<EmployeeDto>>(enteties);
            return dto;
        }
    }
}
