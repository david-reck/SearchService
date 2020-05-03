using iPas.Infrastructure.EventBus.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace PatientSearchService.API
{
    public class PatientsDetailsMessageReceivedEventHandler :
        IIntegrationEventHandler<RegistrationReceivedIntegrationEvent>
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<PatientsDetailsMessageReceivedEventHandler> _logger;
        private IMediator _mediatr;

        public PatientsDetailsMessageReceivedEventHandler(
                        IEventBus eventBus,
                        ILogger<PatientsDetailsMessageReceivedEventHandler> logger,
                        IMediator mediatr
                        )
                    {
                        _eventBus = eventBus;
                        _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
                        _mediatr = mediatr ?? throw new ArgumentNullException(nameof(mediatr));
                    }
        public async Task Handle(RegistrationReceivedIntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
            {

                await Task.CompletedTask;
            }
        }
    }
}
