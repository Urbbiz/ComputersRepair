using ComputerRepair.Data;
using ComputerRepair.Enteties;
using Microsoft.EntityFrameworkCore;

namespace ComputerRepair.Repositories
{
    public class ComputerRepository
    {
        private readonly DataContext _context;

        public ComputerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Post(Computer computer)
        {
            _context.Add(computer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Computer>> GetAll()
        {
            return await _context.Computers.ToListAsync();

        }

        public  Computer FindComputerById(int id)
        {
            var entity = _context.Set<Computer>().FirstOrDefault(c => c.Id == id);
           
            if (entity == null)
            {
                throw new ArgumentException("no such id in database");
            }
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = _context.Set<Computer>().FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _context.Remove(entity);
            }
            await _context.SaveChangesAsync();
        }
    }
}
