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
    public class ComputerController : ControllerBase
    {
        private readonly ComputerRepository _repository;
        private readonly IMapper _mapper;

        public ComputerController(ComputerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task Post(ComputerDto computerDto)
        {
            var entity = _mapper.Map<Computer>(computerDto);    
           await _repository.Post(entity);
        }

        [HttpGet]
        public async Task<List<ComputerDto>> GetAll()
        {
            var enteties = await _repository.GetAll();
            var dto = _mapper.Map<List<ComputerDto>>(enteties);
            return dto;
        }
    }
}
