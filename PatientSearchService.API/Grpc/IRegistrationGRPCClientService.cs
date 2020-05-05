using System.Threading.Tasks;

namespace PatientSearchService.API
{
    public interface IRegistrationGRPCClientService
    {
        Task<Hl7AdtDto> SearchRegistrationDataById(string documentId, int clientId);
    }
}
