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
    public class MaintenanceController : ControllerBase
    {
        private readonly MaintenanceRepository _repository;
        private readonly IMapper _mapper;

        public MaintenanceController(MaintenanceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task Post(MaintenanceDto maintenanceDto)
        {
            var entety = _mapper.Map<Maintenance>(maintenanceDto);
            await _repository.Add(entety);
        }

        [HttpGet]
        public async Task<List<MaintenanceDto>> GetAll()
        {
            var enteties = await _repository.GetAll();
            var dto = _mapper.Map<List<MaintenanceDto>>(enteties);
            return dto;
        }
    }
}
