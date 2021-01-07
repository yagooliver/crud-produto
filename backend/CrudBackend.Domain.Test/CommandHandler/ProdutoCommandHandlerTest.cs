using CrudBackend.Domain.Core.CommandHandlers;
using CrudBackend.Domain.Core.Commands.Produto;
using CrudBackend.Domain.Core.Entity;
using CrudBackend.Domain.Core.Interface;
using CrudBackend.Domain.Core.Interface.Repositorios;
using CrudBackend.Domain.Core.Shared.Handler;
using CrudBackend.Domain.Core.Shared.Notificacao;
using CrudBackend.Infra.Data;
using CrudBackend.Infra.Data.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrudBackend.Domain.Test.CommandHandler
{
    [TestClass]
    public class ProdutoCommandHandlerTest : DbContextFixure
    {
        private IUnitOfWork _unitOfWork;
        private IProdutoRepositorio _produtoRepository;
        private Mock<IMediatorHandler> _mockMediator;
        private NotificacaoDominioHandler _notificacaoDominioHandler;
        private ProdutoCommandHandler _handler;

        [TestInitialize]
        public void Inicializa()
        {
            db = GetDbInstance();
            _unitOfWork = new UnitOfWork(db);
            _produtoRepository = new ProdutoRepositorio(db);
            _mockMediator = new Mock<IMediatorHandler>();
            _notificacaoDominioHandler = new NotificacaoDominioHandler();

            _mockMediator.Setup(x => x.EnviaEvento(It.IsAny<NotificacaoDominio>())).Callback<NotificacaoDominio>((x) =>
            {
                _notificacaoDominioHandler.Handle(x, CancellationToken.None);
            });

            _handler = new ProdutoCommandHandler(_unitOfWork, _produtoRepository, _mockMediator.Object);
        }
        [TestMethod]
        public async Task Nao_deve_salvar_produto_nome_nulo()
        {
            var prod = new ProdutoAddCommand()
            {
                Valor = (decimal)1.59,
                Nome = null,
                Imagem = "/Content/imagens"
            };
            await _handler.Handle(prod, CancellationToken.None);

            Assert.IsTrue(_notificacaoDominioHandler.HasNotifications());
            Assert.AreEqual("'Nome' deve ser informado.", _notificacaoDominioHandler.GetNotificacoes()[0].Value);
        }

        [TestMethod]
        public async Task Nao_deve_salvar_produto_valor_invalido()
        {
            var prod = new ProdutoAddCommand()
            {
                Valor = 0,
                Nome = "",
                Imagem = "/Content/imagens"
            };
            await _handler.Handle(prod, CancellationToken.None);

            Assert.IsTrue(_notificacaoDominioHandler.HasNotifications());
            Assert.AreEqual("Valor deve ser informado e deve ser maior que zero", _notificacaoDominioHandler.GetNotificacoes()[0].Value);
        }

        [TestMethod]
        public async Task Deve_salvar_produto_entidade_valida()
        {
            var prod = new ProdutoAddCommand()
            {
                Valor = (decimal)1.59,
                Nome = "Miojo",
                Imagem = "/Content/imagens"
            };
            await _handler.Handle(prod, CancellationToken.None);

            Assert.IsFalse(_notificacaoDominioHandler.HasNotifications());
        }

        [TestMethod]
        public async Task Deve_salvar_produto_consulta_entidade()
        {
            var prod = new ProdutoAddCommand()
            {
                Valor = (decimal)1.59,
                Nome = "Miojo",
                Imagem = "/Content/imagens"
            };
            await _handler.Handle(prod, CancellationToken.None);

            var produto = _produtoRepository.GetAll().FirstOrDefault();

            Assert.AreEqual(prod.Nome, produto.Nome);
        }

        [TestMethod]
        public async Task Nao_deve_atualizar_produto_id_invalido()
        {
            var prod = new ProdutoAtualizaCommand()
            {
                //Id = produtoId,
                Valor = (decimal)1.59,
                Nome = "Miojo Fortaleza",
                Imagem = "/Content/imagens"
            };

            var resultado = await _handler.Handle(prod, CancellationToken.None);

            Assert.IsFalse(resultado);
            Assert.AreEqual("'Id' deve ser informado.", _notificacaoDominioHandler.GetNotificacoes()[0].Value);
        }

        [TestMethod]
        public async Task Nao_deve_atualizar_produto_inexistente()
        {            
            var prod = new ProdutoAtualizaCommand()
            {
                Id = Guid.NewGuid(),
                Valor = (decimal)1.59,
                Nome = "Miojo Fortaleza",
                Imagem = "/Content/imagens"
            };

            var resultado = await _handler.Handle(prod, CancellationToken.None);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Produto não encontrado!", _notificacaoDominioHandler.GetNotificacoes()[0].Value);
        }

        [TestMethod]
        public async Task Deve_atualizar_produto()
        {
            await Deve_salvar_produto_entidade_valida();
            var produtoId = _produtoRepository.GetAll().FirstOrDefault().Id;
            var prod = new ProdutoAtualizaCommand()
            {
                Id = produtoId,
                Valor = (decimal)1.59,
                Nome = "Miojo Fortaleza",
                Imagem = "/Content/imagens"
            };

            var resultado = await _handler.Handle(prod, CancellationToken.None);

            Assert.IsTrue(resultado);
            Assert.IsFalse(_notificacaoDominioHandler.HasNotifications());
        }

        [TestMethod]
        public async Task Deve_atualizar_produto_checa_alteracao()
        {
            await Deve_salvar_produto_entidade_valida();
            var produtoId = _produtoRepository.GetAll().FirstOrDefault().Id;
            var prod = new ProdutoAtualizaCommand()
            {
                Id = produtoId,
                Valor = (decimal)1.59,
                Nome = "Miojo Fortaleza",
                Imagem = "/Content/imagens"
            };

            var resultado = await _handler.Handle(prod, CancellationToken.None);
            var produto = _produtoRepository.GetAll().FirstOrDefault();

            Assert.AreEqual(prod.Nome, produto.Nome);
            Assert.IsTrue(resultado);
            Assert.IsFalse(_notificacaoDominioHandler.HasNotifications());
        }

        [TestMethod]
        public async Task Nao_deve_deletar_produto_id_invalido()
        {
            var prod = new ProdutoDeletaCommand()
            {
                Id = Guid.Empty                
            };

            var resultado = await _handler.Handle(prod, CancellationToken.None);

            Assert.IsFalse(resultado);
            Assert.AreEqual("'Id' deve ser informado.", _notificacaoDominioHandler.GetNotificacoes()[0].Value);
        }

        [TestMethod]
        public async Task Deve_deletar_produto()
        {
            await Deve_salvar_produto_entidade_valida();
            var produtoId = _produtoRepository.GetAll().FirstOrDefault().Id;
            var prod = new ProdutoAtualizaCommand()
            {
                Id = produtoId,
                Valor = (decimal)1.59,
                Nome = "Miojo Fortaleza",
                Imagem = "/Content/imagens"
            };

            var resultado = await _handler.Handle(prod, CancellationToken.None);

            Assert.IsTrue(resultado);
            Assert.IsFalse(_notificacaoDominioHandler.HasNotifications());
        }

        [TestMethod]
        public async Task Deve_deletar_produto_checa_item()
        {
            await Deve_salvar_produto_entidade_valida();
            var produtoId = _produtoRepository.GetAll().FirstOrDefault().Id;
            var prod = new ProdutoDeletaCommand()
            {
                Id = produtoId,
                Valor = (decimal)1.59,
                Nome = "Miojo Fortaleza",
                Imagem = "/Content/imagens"
            };

            var resultado = await _handler.Handle(prod, CancellationToken.None);
            var produto = _produtoRepository.GetAll().FirstOrDefault();

            Assert.IsNull(produto);
            Assert.IsTrue(resultado);
            Assert.IsFalse(_notificacaoDominioHandler.HasNotifications());
        }

        [TestMethod]
        public async Task Nao_deve_deletar_produto_inexistente()
        {
            var prod = new ProdutoDeletaCommand()
            {
                Id = Guid.NewGuid()
            };

            var resultado = await _handler.Handle(prod, CancellationToken.None);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Produto não encontrado!", _notificacaoDominioHandler.GetNotificacoes()[0].Value);
        }
    }
}
