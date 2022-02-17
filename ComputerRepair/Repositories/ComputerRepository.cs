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

        public async Task Add(Computer computer)
        {
            _context.Add(computer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Computer>> GetAll()
        {
            return await _context.Computers.ToListAsync();

        }
    }
}
