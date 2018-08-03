using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Modelo.Application.Interfaces;
using Modelo.Application.Services;
using Modelo.Domain.Commands.Funcionario;
using Modelo.Domain.Core.Bus;
using Modelo.Domain.Interfaces;
using Modelo.Infra.CrossCutting.Bus;
using Modelo.Infra.Data.Repository;
using Modelo.Infra.Data.UoW;
using Modelo.Infra.Data.Context;
//using Modelo.Infra.Data.Oracle.Repository;
//using Modelo.Infra.Data.Oracle.UoW;
//using Modelo.Infra.Data.Oracle.Context;
//using Modelo.Infra.Data.Oracle.Repository.ReadOnly;
using Modelo.Domain.Core.Notifications;
using Modelo.Domain.Events.Funcionario;
using Modelo.Domain.EventHandlers.Funcioanario;
using Modelo.Domain.CommandHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Interfaces.ReadOnly;
using Modelo.Infra.Data.Repository.ReadOnly;

namespace Modelo.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IFuncionarioAppService, FuncionarioAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<FuncionarioRegisteredEvent>, FuncionarioEventHandler>();
            services.AddScoped<INotificationHandler<FuncionarioUpdatedEvent>, FuncionarioEventHandler>();
            services.AddScoped<INotificationHandler<FuncionarioRemovedEvent>, FuncionarioEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewFuncionarioCommand>, FuncionarioCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateFuncionarioCommand>, FuncionarioCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveFuncionarioCommand>, FuncionarioCommandHandler>();

            // Infra - Data
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IFuncionarioReadOnlyRepository, FuncionarioReadOnlyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ModeloContext>();
        }

        public static void MigrateDB(IApplicationBuilder app)
        {
            //Migration - Data            
            var context = new ModeloContext();
            context.Database.EnsureCreated();
            //if (!context.Database.EnsureCreated())
                //context.Database.Migrate();
        }
    }
}
