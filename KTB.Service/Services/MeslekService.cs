using KTB.Core.Entities;
using KTB.Core.Repositories;
using KTB.Core.Services;
using KTB.Core.UnitOfWorks;

namespace KTB.Service.Services
{
    public class MeslekService : Service<Meslek>, IMeslekService
    {
        public MeslekService(IUnitOfWork unitOfWork, IGenericRepository<Meslek> repository):base(unitOfWork, repository)
        {
           
        }
    }
}
