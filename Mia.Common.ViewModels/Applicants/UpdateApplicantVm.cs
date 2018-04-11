using System;

namespace Mia.Common.ViewModels.Applicants
{
    public class UpdateApplicantVm
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
    }
}