using KTB.Core.Entities;
using System.Threading.Tasks;

namespace KTB.Core.Services
{
    public interface IEserService:IService<Eser>
    {
        Task<Eser> GetWithUyeByIdAsync(int eserId);
    }
}
