using CrudBackend.Application.ViewModels;
using CrudBackend.Domain.Core.Interface.Servicos;
using CrudBackend.Domain.Core.Shared.Handler;
using CrudBackend.Domain.Core.Shared.Helper;
using CrudBackend.Domain.Core.Shared.Notificacao;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrudBackend.Web.Api.Controllers
{
    [ApiController]
    [Route("api/login")]
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService, INotificationHandler<NotificacaoDominio> notificacoes, IMediatorHandler mediator) : base(notificacoes, mediator)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginVM login)
        {
            var autenticado = await AutenticaRequest.LoginAsync(login.Login, login.Senha);
            if (autenticado.Success)
            {
                var token = await Task.Run(() => _loginService.RetornaToken(login.Login));

                return Response(token);
            }
            else
            {
                return Response(autenticado);
            }
        }
    }
}
