using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientSearchService.API
{
    public class gRPCReplyMessage
    {
        public Hl7AdtDto hl7ADTMessage { get; set; }

        public int PatientVisitID { get; set; }
    }
}
