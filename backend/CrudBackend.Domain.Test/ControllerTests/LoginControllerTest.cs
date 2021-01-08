using CrudBackend.Application.Servicos;
using CrudBackend.Application.ViewModels;
using CrudBackend.Domain.Core.Interface.Servicos;
using CrudBackend.Domain.Core.Shared.Handler;
using CrudBackend.Domain.Core.Shared.Models;
using CrudBackend.Domain.Core.Shared.Notificacao;
using CrudBackend.Web.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class LoginControllerTest
    {
        private ILoginService _loginService;
        private Mock<IMediatorHandler> _mockMediator;
        private NotificacaoDominioHandler _notificacaoDominioHandler;
        private LoginController _controller;

        [TestInitialize]
        public void InitTests()
        {
            var mockConfig = new Mock<IConfiguration>();

            mockConfig.Setup(x => x[It.Is<string>(s => s.Equals("Jwt:Issuer"))])
                .Returns("Teste");

            mockConfig.Setup(x => x[It.Is<string>(s => s.Equals("Jwt:Duration"))])
                .Returns("120");

            mockConfig.Setup(x => x[It.Is<string>(s => s.Equals("Jwt:Key"))])
                .Returns("IZpipYfLNJro403p");

            _mockMediator = new Mock<IMediatorHandler>();
            _notificacaoDominioHandler = new NotificacaoDominioHandler();
            _mockMediator.Setup(x => x.EnviaEvento(It.IsAny<NotificacaoDominio>())).Callback<NotificacaoDominio>((x) =>
            {
                _notificacaoDominioHandler.Handle(x, CancellationToken.None);
            });

            _loginService = new LoginService(mockConfig.Object);
            _controller = new LoginController(_loginService, _notificacaoDominioHandler, _mockMediator.Object);
        }

        [TestMethod]
        public async Task Nao_deve_autenticar()
        {
            var resultado = (await _controller.LoginAsync(new LoginVM("admin", "admin")) as OkObjectResult).Value as ApiSucesso;
            var autenticado = resultado.Data as ResultadoApi;
            Assert.IsFalse(autenticado.Success);
            Assert.AreEqual("authentication username or password invalid", autenticado.Error);
        }

        [TestMethod]
        public async Task Deve_autenticar_retorna_token()
        {
            var resultado = (await _controller.LoginAsync(new LoginVM("11234567890", "09876543211")) as OkObjectResult).Value as ApiSucesso;
            var autenticado = resultado.Data as TokenJWT;
            Assert.IsTrue(autenticado.Autenticado);
            Assert.IsNotNull(autenticado.Token);
        }
    }
}
