using System;
using System.Collections.Generic;
using Mia.Cargo.Webapi.ViewModels;
using Mia.Common.ViewModels.Applicants;

namespace Mia.Cargo.ViewModels
{
    public class NewPolicyVm
    {
        public ApplicantListItemVm Applicant { get; set; }
        public InsuredVm Insured { get; set; }
        public ShippingVm Shipping { get; set; }
        public CargoVm Cargo { get; set; }
        public IList<string> StandardClauseIds { get; set; }
        public string LcClauses { get; set; }
        public string Excess { get; set; }
        public DateTime IssueDate { get; set; }

    }

   
}