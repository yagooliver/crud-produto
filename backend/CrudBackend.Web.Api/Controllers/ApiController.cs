using CrudBackend.Domain.Core.Shared.Handler;
using CrudBackend.Domain.Core.Shared.Models;
using CrudBackend.Domain.Core.Shared.Notificacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrudBackend.Web.Api.Controllers
{
    [ApiController]
    public class ApiController : Controller
    {
        protected readonly NotificacaoDominioHandler _notificacoes;
        protected readonly IMediatorHandler _mediator;

        protected ApiController(INotificationHandler<NotificacaoDominio> notificacao,
                                IMediatorHandler mediator)
        {
            _notificacoes = (NotificacaoDominioHandler)notificacao;
            _mediator = mediator;
        }

        protected IEnumerable<NotificacaoDominio> Notifications => _notificacoes.GetNotificacoes();

        protected bool EhOperacaoValida()
        {
            return (!_notificacoes.HasNotifications());
        }

        protected new IActionResult Response(object result = null)
        {
            if (EhOperacaoValida())
            {
                return Ok(new ApiSucesso
                {
                    Sucesso = true,
                    Data = result
                });
            }

            return BadRequest(new ApiErro
            {
                Sucesso = false,
                erros = _notificacoes.GetNotificacoes().Select(n => n.Value).ToList()
            });
        }

        protected void NotificaErrosModelState()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificaErro(string.Empty, erroMsg);
            }
        }

        protected void NotificaErro(string code, string message)
        {
            _mediator.EnviaEvento(new NotificacaoDominio(code, message));
        }
    }
}
