using ComputerRepair.Data;
using ComputerRepair.Enteties;
using Microsoft.EntityFrameworkCore;

namespace ComputerRepair.Repositories
{
    public class MaintenanceRepository
    {
        private readonly DataContext _context;

        public MaintenanceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Maintenance maintenance)
        {
            _context.Add(maintenance);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Maintenance>> GetAll()
        {
            return await _context.Maitences.ToListAsync();

        }
    }
}
