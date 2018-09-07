using System.Threading.Tasks;
using Vuighe.Model.Entities;
using Vuighe.Service.Dtos.LoginHistory;

namespace Vuighe.Service.Interfaces
{
    public interface ILoginHistoryService: IService<LoginHistory>
    {
        bool CheckTokenLoginNeareast(CheckTokenLoginNeareastDto checkTokenLoginNeareastDto);
    }
}