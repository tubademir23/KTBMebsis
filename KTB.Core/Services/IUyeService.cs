using KTB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KTB.Core.Services
{
    public interface IUyeService:IService<Uye>
    {
        Task<Uye> GetWithEserByIdAsync(int uyeId);
    }
}
