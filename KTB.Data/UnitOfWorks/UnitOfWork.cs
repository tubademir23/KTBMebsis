using KTB.Core.Repositories;
using KTB.Core.UnitOfWorks;
using KTB.Data.Repositories;
using System.Threading.Tasks;

namespace KTB.Data.UnitOfWorks
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IEserRepository _eserRepository;
        private IUyeRepository _uyeRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IEserRepository Eser => _eserRepository= _eserRepository ?? new EserRepository(_context);

        public IUyeRepository Uye => _uyeRepository = _uyeRepository ?? new UyeRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAysnc()
        {
            await _context.SaveChangesAsync();
        }
    }
}
