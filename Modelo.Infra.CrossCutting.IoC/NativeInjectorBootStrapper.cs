using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Modelo.Application.Interfaces;
using Modelo.Application.Services;
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
using Microsoft.AspNetCore.Builder;
using Modelo.Domain.Interfaces.ReadOnly;
using Modelo.Infra.Data.Repository.ReadOnly;
using Modelo.Domain.Commands.Funcionario.Denormalize;
using Modelo.Domain.Core.Bus.Normalize;
using Modelo.Domain.Commands.Funcionario.Normalize;
using Modelo.Domain.CommandHandlers.Normalize;
using Modelo.Domain.CommandHandlers.Denormalize;
using Modelo.Domain.Core.Bus.Denormalize;
using Infra.Data.Mongo.Repository;
using Infra.Data.Mongo.Context;
using Modelo.Domain.Interfaces.Denormalize;

namespace Modelo.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            //services.AddScoped<IMediatorHandlerNormalize, InMemoryBusNormalize>();
            //services.AddScoped<IMediatorHandlerDenormalize, InMemoryBusDenormalize>();

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

            services.AddScoped<IRequestHandler<RegisterNewFuncionarioDenormalize>, FuncionarioDenormalizeHandler>();
            services.AddScoped<IRequestHandler<UpdateFuncionarioDenormalize>, FuncionarioDenormalizeHandler>();
            services.AddScoped<IRequestHandler<RemoveFuncionarioDenormalize>, FuncionarioDenormalizeHandler>();

            // Infra - Data
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IFuncionarioReadOnlyRepository, FuncionarioReadOnlyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ModeloContext>();

            services.AddScoped<IFuncionarioRepositoryDenormalize, FuncionarioRepositoryDenormalize>();
            services.AddScoped<IFuncionarioReadOnlyRepositoryDenormalize, FuncionarioReadOnlyRepositoryDenormalize>();
            services.AddScoped<MongoDbContext>();

            //RabbitMQ - infra
            services.AddScoped<IMediatorHandlerNormalize, InMemoryBusNormalize>();
            services.AddScoped<IMediatorHandlerDenormalize, InMemoryBusDenormalize>();
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
