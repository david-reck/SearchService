using Grpc.Net.Client;
using Newtonsoft.Json;
using RegistrationService.API.Grpc;
using System;
using System.Threading.Tasks;

namespace PatientSearchService.API
{
    public class RegistrationGRPCClientService : IRegistrationGRPCClientService
    {
        private string _grpcClientAddress;
        public RegistrationGRPCClientService(string address)
        {
            _grpcClientAddress = address;
        }

        public Task<Hl7AdtDto> SearchRegistrationDataById(string documentId, int clientId)
        {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                var registrationChannel = GrpcChannel.ForAddress(_grpcClientAddress);
                var registrationClient = new RegistrationApiRetrieval.RegistrationApiRetrievalClient(registrationChannel);
                var adtMessageRequest = new SearchAPIAdtMessageRequest { Id = documentId, ClientId = clientId };
                var reply = registrationClient.SearchAPIFindAdtMessageById(adtMessageRequest);
                Hl7AdtDto message = JsonConvert.DeserializeObject<Hl7AdtDto>(reply.AdtMessage);

                return Task.FromResult(message);
        }
    }
}
