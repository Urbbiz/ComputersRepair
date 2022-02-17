using ComputerRepair.Data;
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

        public ComputerController(ComputerRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task Post(Computer computer)
        {
           await _repository.Add(computer);
        }

        [HttpGet]
        public async Task<List<Computer>> GetAll()
        {
            var items = await _repository.GetAll();
            return items;
        }
    }
}
