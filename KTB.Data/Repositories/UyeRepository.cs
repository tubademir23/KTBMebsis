using KTB.Core.Entities;
using KTB.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KTB.Data.Repositories
{
    public class UyeRepository : Repository<Uye>, IUyeRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public UyeRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Uye> GetWithEserByIdAsync(int uyeId)
        {
           return await _appDbContext.Uye.Include(x => x.Eserler).SingleOrDefaultAsync(x => x.Id == uyeId);
        }
    }
}
