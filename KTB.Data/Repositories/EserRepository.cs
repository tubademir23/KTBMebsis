using KTB.Core.Entities;
using KTB.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KTB.Data.Repositories
{
    public class EserRepository : Repository<Eser>, IEserRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public EserRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<Eser> GetWithUyeByIdAsync(int eserId)
        {
            return await _appDbContext.Eser.Include(x => x.Uye).SingleOrDefaultAsync(x => x.Id == eserId);
        }
    }
}
