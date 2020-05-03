using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientSearchService.Data
{
    class FindPatientDetailsQuery : IRequest<FindPatientDetailsResult>
    {
        public string QueryText { get; set; }
    }
}
