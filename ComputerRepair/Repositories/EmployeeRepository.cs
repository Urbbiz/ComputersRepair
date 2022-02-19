using ComputerRepair.Data;
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

        public Employee FindEmployeeById(int id)
        {
            var entity = _context.Set<Employee>().FirstOrDefault(e => e.Id == id);  
            if (entity == null)
            {
                throw new ArgumentException("no such id in database");
            }
            return entity;
        }
    }
}
