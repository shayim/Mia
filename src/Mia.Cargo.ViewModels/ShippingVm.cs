using System;

namespace Mia.Cargo.Webapi.ViewModels
{
    public class ShippingVm
    {
        public string TypeId { get; set; }
        public string WaybillNumber { get; set; }
        public string Conveyance { get; set; }
        public DateTime Etd { get; set; }
        public string OriginCountryId { get; set; }
        public string OriginCity { get; set; }
        public string DestinationCountryId { get; set; }
        public string DestinationCity { get; set; }
        public string Via { get; set; }
        public string ShippingMarks { get; set; }
     
    }
}