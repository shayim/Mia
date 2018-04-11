namespace Mia.Common.ViewModels.Applicants
{
    public class NewApplicantVm
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public int IdentityDocumentTypeId { get; set; }
        public string IdentityDocumentNumber { get; set; }
    }
}