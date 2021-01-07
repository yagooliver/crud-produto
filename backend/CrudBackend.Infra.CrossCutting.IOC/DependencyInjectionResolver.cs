using CrudBackend.Application.Servicos;
using CrudBackend.Domain.Core.CommandHandlers;
using CrudBackend.Domain.Core.Commands.Produto;
using CrudBackend.Domain.Core.Interface;
using CrudBackend.Domain.Core.Interface.Repositorios;
using CrudBackend.Domain.Core.Interface.Servicos;
using CrudBackend.Domain.Core.Shared.Handler;
using CrudBackend.Domain.Core.Shared.Notificacao;
using CrudBackend.Infra.CrossCutting.Bus;
using CrudBackend.Infra.Data;
using CrudBackend.Infra.Data.Context;
using CrudBackend.Infra.Data.Repositorios;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CrudBackend.Infra.CrossCutting.IOC
{
    public class DependencyInjectionResolver
    {
        public static void RegistraServicos(IServiceCollection services)
        {
            services.AddDbContext<CrudContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //MediatR
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            services.AddScoped<IRequestHandler<ProdutoAddCommand, Guid>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<ProdutoAtualizaCommand, bool>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<ProdutoDeletaCommand, bool>, ProdutoCommandHandler>();

            services.AddScoped<IProdutoService, ProducoServico>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddScoped<INotificationHandler<NotificacaoDominio>, NotificacaoDominioHandler>();
        }
    }
}
