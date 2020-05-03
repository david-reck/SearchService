using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientSearchService.API
{
    public class PatientSearchRepository : IPatientSearchRepository
    {

        protected readonly ElasticSearchClient ElasticSearchClient;
        protected readonly string IndexName;


        public PatientSearchRepository(ElasticSearchClient elasticClient, string indexName)
        {
            this.ElasticSearchClient = elasticClient;
            this.IndexName = indexName;
        }


        public async Task AddAndSaveToES(PatientDetailDto PatientDetail)
        {
           await ElasticSearchClient.GetClient().IndexDocumentAsync(PatientDetail);
        }

        public async Task<bool> CreateIndexIfNotExist()
        {
            if (IndexExist()) return true;
            var response = await CreateIndexAsync();

            if (!response.IsValid)
            {
                return false;
                throw new Exception(response.ServerError.ToString(), response.OriginalException);
            }

            return true;
        }

        protected async Task<IResponse> CreateIndexAsync()
        {
            var indexDescriptor = new CreateIndexDescriptor(IndexName).Map(m => m.AutoMap());
            var response = await ElasticSearchClient.GetClient().Indices.CreateAsync(IndexName,
                    index => index.Map<PatientDetailDto>(
                        x => x.AutoMap()
                    ));
            return response;
        }

        protected bool IndexExist()
        {
            return ElasticSearchClient.GetClient().Indices.Exists(IndexName).Exists;
        }

        public async Task<List<PatientDetailDto>> FindPatientDetails(string queryText)
        {
            var result = await ElasticSearchClient.GetClient()
                .SearchAsync<PatientDetailDto>(
                    s =>
                        s.From(0)
                        .Size(10)
                        .Query(q =>
                            q.MultiMatch(mm =>
                                mm.Query(queryText)
                                .Fields(f => f.Fields(p => p.ClientID, p => p.AccountNumber))
                                .Type(TextQueryType.BestFields)
                                .Fuzziness(Fuzziness.Auto)
                            )
                    ));

            return result.Documents.ToList();
        }

    }
}
