using KTB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KTB.Core.Repositories
{
    public interface IUyeRepository:IGenericRepository<Uye>
    {
        Task<Uye> GetWithEserByIdAsync(int uyeId);


    }
}
