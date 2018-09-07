using System;
using System.Linq;
using System.Threading.Tasks;
using Vuighe.Model;
using Vuighe.Model.Entities;
using Vuighe.Service.Dtos.LoginHistory;
using Vuighe.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Vuighe.Service.Implementations
{
    public class LoginHistoryService: BaseService<LoginHistory>, ILoginHistoryService
    {
        public LoginHistoryService(AppDbContext context) : base(context)
        {
        }

        public bool CheckTokenLoginNeareast(CheckTokenLoginNeareastDto checkTokenLoginNeareastDto)
        {
            var now = DateTime.Now;
            var query = this.Queryable().OrderByDescending(x => x.CreatedDate)
                .AsNoTracking()
                .FirstOrDefault(x => x.Username == checkTokenLoginNeareastDto.Username);
            if (query != null && query.Token == checkTokenLoginNeareastDto.Token)
            {
                var timeDifference = (now - query.CreatedDate).TotalSeconds;
                if (timeDifference <= 3600)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}