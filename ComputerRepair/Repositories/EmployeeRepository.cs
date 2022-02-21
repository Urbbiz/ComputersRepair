using ComputerRepair.Data;
using ComputerRepair.Dtos;
using ComputerRepair.Enteties;
using Microsoft.EntityFrameworkCore;

namespace ComputerRepair.Repositories
{
    public class EmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Post(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();

        }

        public async Task<List<Employee>> GetSortByLastName()
        {
            return await _context.Employees.OrderBy( e => e.LastName).ToListAsync();    
        }

        public async Task<List<EmployeeGetDto>> GetAllDto()
        {
            
            var entity = await _context.Employees.Select(e => new EmployeeGetDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                Age = e.Age,
                LastName = e.LastName,
                Position = e.Position,
                Computers = (ICollection<Computer>)e.Computers,
            }).ToListAsync();
            return entity;
            // return await _context.Employees.ToListAsync();
        }

        public async Task<List<EmployeeMaintenanceDto>> GetEmployeeMaintenance()
        {
           return await _context.Employees.Select(e => new EmployeeMaintenanceDto { FirstName = e.FirstName,
            LastName = e.LastName, Cost = e.Computers.SelectMany(c => c.Maintenances).
            Where(m => m.Date > DateTime.UtcNow.AddYears(-2 )).Sum(m => m.Cost)}).Where(m => m.Cost != 0).ToListAsync();
        }

        public Employee FindEmployeeById(int id)
        {
            var entity = _context.Set<Employee>().FirstOrDefault(e => e.Id == id);  
            if (entity == null)
            {
                throw new ArgumentException("no such id in database");
            }
            return entity;
        }

        public async Task Delete(int id)
        {
            var employee = _context.Set<Employee>().FirstOrDefault(e => e.Id == id);

            if (employee != null)
                {
                _context.Remove(employee);
            }
            await _context.SaveChangesAsync();
        }
    }
}
