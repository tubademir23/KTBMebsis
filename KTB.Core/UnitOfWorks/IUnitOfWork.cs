using KTB.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KTB.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IEserRepository Eser { get; }
        IUyeRepository Uye { get; }

        Task CommitAysnc();
        void Commit();

    }
}
