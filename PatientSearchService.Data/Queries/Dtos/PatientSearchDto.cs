﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientSearchService.Data
{
    public class PatientSearchDto
    {
        [JsonProperty("AccountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("FinancialClass")]
        public string FinancialClass { get; set; }

        [JsonProperty("PatientType")]
        public string PatientType { get; set; }

        [JsonProperty("MRN")]
        public string MRN { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("DOS")]
        public string DOS { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }
    }
}
