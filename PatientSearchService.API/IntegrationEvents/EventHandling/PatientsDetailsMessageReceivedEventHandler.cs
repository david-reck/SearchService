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
        private IRegistrationGRPCClientService _grpcRegistrationService;

        public PatientsDetailsMessageReceivedEventHandler(
                        IEventBus eventBus,
                        ILogger<PatientsDetailsMessageReceivedEventHandler> logger,
                        IMediator mediatr,
                        IRegistrationGRPCClientService registrationService
                        )
        {
            _eventBus = eventBus;
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            _mediatr = mediatr ?? throw new ArgumentNullException(nameof(mediatr));
            _grpcRegistrationService = registrationService ?? throw new ArgumentNullException(nameof(registrationService));
        }
        public async Task Handle(RegistrationReceivedIntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
            {
                Hl7AdtDto message = await _grpcRegistrationService.SearchRegistrationDataById(@event.DocumentId, @event.ClientId);

                    string[] format = { "yyyyMMdd" };
                    DateTime date;

                    DateTime.TryParseExact(message.Hl7Message.Pid.Pid7.Pid71,
                                               format,
                                               System.Globalization.CultureInfo.InvariantCulture,
                                               System.Globalization.DateTimeStyles.None,
                                               out date);

                    var command = new CreateUpdatePatientDetailsInESCommand(message.Hl7Message.Pid.Pid18.Pid181, date, "Payer1",
                                                                             message.Hl7Message.Pid.Pid19.Pid191, message.Hl7Message.Pv1.Pv120.Pv1201,
                                                                             message.Hl7Message.Pv1.Pv118.ToString(), message.Hl7Message.Pid.Pid3.Pid31.ToString(), message.Hl7Message.Pid.Pid5.Pid51,
                                                                             message.Hl7Message.Pid.Pid5.Pid52, message.Hl7Message.Pv1.Pv14.Pv141,
                                                                             message.Hl7Message.Pv2.Pv224.Pv2241, "HAR1", @event.ClientId.ToString(), @event.PatientVisitId.ToString(),
                                                                             "Registrar", "DOS", message.Hl7Message.Pid.Pid8.Pid81);

                    _logger.LogInformation("-----Sending command: RunRegistrationRulesCommand");

                    await _mediatr.Publish(command);
                await Task.CompletedTask;
            }
        }
    }
}
