﻿using TesteSoftplan.Application.Interfaces;
using TesteSoftplan.Application.Services;
using TesteSoftplan.Domain.Events;
using TesteSoftplan.Domain.Interfaces;
using TesteSoftplan.Infra.CrossCutting.Bus;
using TesteSoftplan.Infra.Data.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;
using TesteSoftplan.Domain.Interfaces.ApiExternal;
using TesteSoftplan.Infra.Data.ApiExternal;
using TesteSoftplan.Domain.Core.Events;
using Equinox.Infra.Data.EventSourcing;
using Equinox.Infra.Data.Repository.EventSourcing;

namespace TesteSoftplan.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IEventStore, EventStore>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IJurosAppService, JurosAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<JurosRegisteredEvent>, JurosEventHandler>();
            services.AddScoped<INotificationHandler<JurosUpdatedEvent>, JurosEventHandler>();
            services.AddScoped<INotificationHandler<JurosRemovedEvent>, JurosEventHandler>();

            // Infra - Data
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IJurosRepository, JurosRepository>();
            services.AddHttpClient<IApiOneHttpClient, ApiOneHttpClient>();
        }
    }
}