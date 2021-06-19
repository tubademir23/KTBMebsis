using KTB.Core.Entities;
using KTB.Core.Repositories;
using KTB.Core.Services;
using KTB.Core.UnitOfWorks;
using System.Threading.Tasks;

namespace KTB.Service.Services
{
    public class EserService : Service<Eser>, IEserService
    {
        public EserService(IUnitOfWork unitOfWork, IGenericRepository<Eser> repository):base(unitOfWork, repository)
        {
           
        }
        public async Task<Eser> GetWithUyeByIdAsync(int eserId)
        {
            return await _unitOfWork.Eser.GetWithUyeByIdAsync(eserId);

        }
    }
}
