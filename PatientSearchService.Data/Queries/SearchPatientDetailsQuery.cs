using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientSearchService.Data
{
    public class SearchPatientDetailsQuery : IRequest<SearchPatientDetailsResult>
    {
        public string QueryText { get; set; }
    }
}
