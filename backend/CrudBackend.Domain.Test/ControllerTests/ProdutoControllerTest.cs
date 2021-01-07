using CrudBackend.Application.Servicos;
using CrudBackend.Domain.Core.Entity;
using CrudBackend.Domain.Core.Interface;
using CrudBackend.Domain.Core.Interface.Repositorios;
using CrudBackend.Domain.Core.Interface.Servicos;
using CrudBackend.Domain.Core.Shared.Handler;
using CrudBackend.Domain.Core.Shared.Models;
using CrudBackend.Domain.Core.Shared.Notificacao;
using CrudBackend.Infra.Data;
using CrudBackend.Infra.Data.Repositorios;
using CrudBackend.Web.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrudBackend.Domain.Test.ControllerTests
{
    [TestClass]
    public class ProdutoControllerTest : DbContextFixure
    {
        private IProdutoService _produtoService;
        private IUnitOfWork _unitOfWork;
        private IProdutoRepositorio _produtoRepository;
        private Mock<IMediatorHandler> _mockMediator;
        private NotificacaoDominioHandler _notificacaoDominioHandler;
        private ProdutoController _controller;
        private Produto produto;
        private Produto produto2;

        [TestInitialize]
        public void Inicializa()
        {
            _mockMediator = new Mock<IMediatorHandler>();
            _notificacaoDominioHandler = new NotificacaoDominioHandler();
            _mockMediator.Setup(x => x.EnviaEvento(It.IsAny<NotificacaoDominio>())).Callback<NotificacaoDominio>((x) =>
            {
                _notificacaoDominioHandler.Handle(x, CancellationToken.None);
            });
            db = GetDbInstance();
            _unitOfWork = new UnitOfWork(db);
            _produtoRepository = new ProdutoRepositorio(db);

            var _produtoService = new ProducoServico(_produtoRepository);

            produto = new Produto("Miojo", (decimal)1.59, "/Content/Imagem");
            _produtoRepository.Add(produto);
            produto2 = new Produto("Feijão(1kg)", (decimal)9.59, "/Content/Imagem2");
            _produtoRepository.Add(produto2);
            _unitOfWork.Commit();

            _controller = new ProdutoController(_produtoService, _notificacaoDominioHandler, _mockMediator.Object);
        }

        [TestMethod]
        public async Task Deve_buscar_todos_os_produtos()
        {
            var resultado = (await _controller.Get() as OkObjectResult).Value as ApiSucesso;
            var produtos = resultado.Data as List<Produto>;

            Assert.IsTrue(produtos.Any());
            Assert.AreEqual(2, produtos.Count);
        }

        [TestMethod]
        public async Task Deve_buscar_o_produto_um()
        {
            var resultado = (await _controller.Get(produto.Id) as OkObjectResult).Value as ApiSucesso;
            var consulta = resultado.Data as Produto;

            Assert.IsTrue(consulta != null);
            Assert.AreEqual(produto.Nome, consulta.Nome);
        }

        [TestMethod]
        public async Task Deve_buscar_o_produto_dois()
        {
            var resultado = (await _controller.Get(produto2.Id) as OkObjectResult).Value as ApiSucesso;
            var consulta = resultado.Data as Produto;

            Assert.IsTrue(consulta != null);
            Assert.AreEqual(produto2.Nome, consulta.Nome);
        }
    }
}
