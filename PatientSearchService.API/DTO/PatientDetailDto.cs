using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientSearchService.API
{
    public class PatientDetailDto
    {
        public string AccountNumber { get; set; }

        public DateTimeOffset AdmitStartDate { get; set; }
        public DateTimeOffset AdmitEndDate { get; set; }

        public string PayerCode { get; set; }

        public string SSN { get; set; }

        public string FinancialClass { get; set; }

        public string PatientType { get; set; }

        public string MRN { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AdmitType { get; set; }

        public string Status { get; set; }

        public string HAR { get; set; }

        public string ClientID { get; set; }

        public int PatientVisitID { get; set; }

        public string Registrar { get; set; }

        public int DOS { get; set; }
    }
}
