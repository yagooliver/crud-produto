using CrudBackend.Domain.Core.Commands.Produto;
using CrudBackend.Domain.Core.Interface.Servicos;
using CrudBackend.Domain.Core.Shared.Handler;
using CrudBackend.Domain.Core.Shared.Notificacao;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CrudBackend.Web.Api.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService, INotificationHandler<NotificacaoDominio> notificacoes, IMediatorHandler mediator) : base(notificacoes, mediator)
        {
            _produtoService = produtoService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await Task.Run(() => _produtoService.GetProdutos());

            return Response(produtos);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var produto = await Task.Run(() => _produtoService.GetProduto(id));

            return Response(produto);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(ProdutoAddCommand comando) => Response(await _mediator.ExecutaComando(comando));

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put(ProdutoAtualizaCommand comando) => Response(await _mediator.ExecutaComando(comando));

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(ProdutoDeletaCommand comando) => Response(await _mediator.ExecutaComando(comando));
    }
}
