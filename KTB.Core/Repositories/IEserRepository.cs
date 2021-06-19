using KTB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KTB.Core.Repositories
{
    public interface IEserRepository:IGenericRepository<Eser>
    {
        Task<Eser> GetWithUyeByIdAsync(int eserId);

    }
}
