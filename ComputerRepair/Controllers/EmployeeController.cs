using ComputerRepair.Data;
using ComputerRepair.Enteties;
using Microsoft.AspNetCore.Mvc;

namespace ComputerRepair.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Post(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }
    }
}
