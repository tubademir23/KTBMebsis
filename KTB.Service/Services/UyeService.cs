using KTB.Core.Entities;
using KTB.Core.Repositories;
using KTB.Core.Services;
using KTB.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KTB.Service.Services
{
    public class UyeService : Service<Uye>, IUyeService
    {
        public UyeService(IUnitOfWork unitOfWork, IGenericRepository<Uye> repository):base(unitOfWork, repository)
        {
           
        }

        
        public async Task<Uye> GetWithEserByIdAsync(int uyeId)
        {
            return await _unitOfWork.Uye.GetWithEserByIdAsync(uyeId);
        }
    }
}
