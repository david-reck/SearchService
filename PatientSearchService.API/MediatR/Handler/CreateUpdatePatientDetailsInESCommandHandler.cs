using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PatientSearchService.API
{
    public class CreateUpdatePatientDetailsInESCommandHandler : INotificationHandler<CreateUpdatePatientDetailsInESCommand>
    {
        protected readonly IPatientSearchRepository _patientsearchrepository;

        public CreateUpdatePatientDetailsInESCommandHandler(IPatientSearchRepository Patientsearchrepository)
        {
            this._patientsearchrepository = Patientsearchrepository;
        }
        public Task Handle(CreateUpdatePatientDetailsInESCommand notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
