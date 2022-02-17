using ComputerRepair.Data;
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

        public MaintenanceController(MaintenanceRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task Post(Maintenance maintenance)
        {
            await _repository.Add(maintenance);
        }

        [HttpGet]
        public async Task<List<Maintenance>> GetAll()
        {
            var items = await _repository.GetAll();
            return items;
        }
    }
}
