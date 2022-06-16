using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Teste.BancoMaster.Application.Interfaces;
using Teste.BancoMaster.Application.Services;
using Teste.BancoMaster.CC.Bus;
using Teste.BancoMaster.Domain.Commands;
using Teste.BancoMaster.Domain.Core.Bus;
using Teste.BancoMaster.Domain.Core.Notification;
using Teste.BancoMaster.Domain.Events;
using Teste.BancoMaster.Domain.Interfaces;
using Teste.BancoMaster.Infra.Data.Context;
using Teste.BancoMaster.Infra.Data.Repository;
using Teste.BancoMaster.Infra.Data.UoW;

namespace Teste.BancoMaster.CC.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IRotaAppService, RotaAppService>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<RotaRegisteredEvent>, RotaEventHandler>();
            services.AddScoped<INotificationHandler<RotaUpdatedEvent>, RotaEventHandler>();
            services.AddScoped<INotificationHandler<RotaRemovedEvent>, RotaEventHandler>();

            services.AddScoped<IRequestHandler<RegisterNewRotaCommand, bool>, RotaCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateRotaCommand, bool>, RotaCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveRotaCommand, bool>, RotaCommandHandler>();

            services.AddScoped<IRotaRepository, RotaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<TesteContext>();

        }
    }
}
