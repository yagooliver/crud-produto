using CrudBackend.Domain.Core.Commands.Produto;
using CrudBackend.Domain.Core.Entity;
using CrudBackend.Domain.Core.Interface;
using CrudBackend.Domain.Core.Interface.Repositorios;
using CrudBackend.Domain.Core.Shared.Handler;
using CrudBackend.Domain.Core.Shared.Notificacao;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrudBackend.Domain.Core.CommandHandlers
{
    public class ProdutoCommandHandler :
        IRequestHandler<ProdutoAddCommand, Guid>,
        IRequestHandler<ProdutoAtualizaCommand, bool>,
        IRequestHandler<ProdutoDeletaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMediatorHandler _mediatorHandler;

        public ProdutoCommandHandler(IUnitOfWork unitOfWork, IProdutoRepositorio produtoRepositorio, IMediatorHandler mediatorHandler)
        {
            _unitOfWork = unitOfWork;
            _produtoRepositorio = produtoRepositorio;
            _mediatorHandler = mediatorHandler;
        }

        public Task<Guid> Handle(ProdutoAddCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                Produto produto = new Produto(request.Nome, request.Valor, request.Imagem);

                _produtoRepositorio.Add(produto);
                _unitOfWork.Commit();

                return Task.FromResult(produto.Id);
            }
            else
            {
                foreach(var erro in request.RetornaErros())
                {
                    _mediatorHandler.EnviaEvento(new NotificacaoDominio(erro.ErrorCode, erro.ErrorMessage));
                }
            }

            return Task.FromResult<Guid>(Guid.Empty);
        }

        public Task<bool> Handle(ProdutoAtualizaCommand request, CancellationToken cancellationToken)
        {
            if(request.IsValid())
            {
                Produto produto = _produtoRepositorio.GetById(request.Id);
                if(produto != null)
                {
                    produto.AtualizaCampos(request.Nome, request.Valor, request.Imagem);
                    _produtoRepositorio.Update(produto);

                    var resultado = _unitOfWork.Commit();

                    return Task.FromResult(resultado);
                }
                else
                {
                    _mediatorHandler.EnviaEvento(new NotificacaoDominio("Erro", "Produto não encontrado!"));
                }
            }
            else
            {
                foreach (var erro in request.RetornaErros())
                {
                    _mediatorHandler.EnviaEvento(new NotificacaoDominio(erro.ErrorCode, erro.ErrorMessage));
                }
            }

            return Task.FromResult(false);
        }

        public Task<bool> Handle(ProdutoDeletaCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                Produto produto = _produtoRepositorio.GetById(request.Id);
                if (produto != null)
                {
                    _produtoRepositorio.Remove(produto);

                    var resultado = _unitOfWork.Commit();

                    return Task.FromResult(resultado);
                }
                else
                {
                    _mediatorHandler.EnviaEvento(new NotificacaoDominio("Erro", "Produto não encontrado!"));
                }
            }
            else
            {
                foreach (var erro in request.RetornaErros())
                {
                    _mediatorHandler.EnviaEvento(new NotificacaoDominio(erro.ErrorCode, erro.ErrorMessage));
                }
            }

            return Task.FromResult(false);
        }
    }
}
