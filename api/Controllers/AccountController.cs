using System.Threading.Tasks;
using api.Controllers;
using api.Domain.ViewModels;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Controllers
{
    public class AccountController : BaseApiController
    {
        private IClienteService _service;
        private IMapper _mapper;
        private ILoginService _loginService;

        public AccountController(
            ILogger<AccountController> logger,
            IClienteService service,
            IMapper mapper,
            ILoginService loginService

        ) :
            base(logger, mapper)
        {
            _mapper = mapper;
            _service = service;
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginViewModel>> Login(string login, string senha)
        {
            return await _loginService.ValidateUser(login,senha);
        }
    }
}