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
        private readonly ComputerRepository _computerRepository;
        private readonly IMapper _mapper;

        public MaintenanceController(MaintenanceRepository repository,
            ComputerRepository computerRepository, IMapper mapper)
        {
            _repository = repository;
            _computerRepository = computerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<MaintenanceDto>> GetAll()
        {
            var enteties = await _repository.GetAll();
            var dto = _mapper.Map<List<MaintenanceDto>>(enteties);
            return dto;
        }

        [HttpPost]
        public async Task Post(MaintenanceDto maintenanceDto)
        {
            var entity = _mapper.Map<Maintenance>(maintenanceDto);

            var computer =_computerRepository.FindComputerById(entity.ComputerId);
            
            if (computer == null)
            {
                throw new ArgumentException("no such id in database");
                BadRequest();
            }
           

            await _repository.Add(entity);
        }

    }
}
