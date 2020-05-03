using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientSearchService.API
{
    public interface IPatientSearchRepository
    {
        Task<bool> CreateIndexIfNotExist();
        Task AddAndSaveToES(PatientDetailDto PatientDetail);
        Task<List<PatientDetailDto>> FindPatientDetails(string queryText);
    }
}
