using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vuighe.Service.Dtos.LoginHistory;
using Vuighe.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vuighe.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ILoginHistoryService _historyService;

        public AccountController(ILoginHistoryService historyService)
        {
            _historyService = historyService;
        }

        [AllowAnonymous]
        [HttpPost("checkToken")]
        public bool CheckToken(CheckTokenLoginNeareastDto checkTokenLoginNeareastDto)
        {
            var result = _historyService.CheckTokenLoginNeareast(checkTokenLoginNeareastDto);
            return result;
        }
    }
}