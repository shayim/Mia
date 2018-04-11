namespace Mia.Cargo.ViewModels
{
    public class CargoVm
    {
        public string Description { get; set; }
        public string Packing { get; set; }
        public string PackingCategoryId { get; set; }
        public string HsCode { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceCurrency { get; set; }
        public decimal InvoiceValue { get; set; }
        public decimal Markup { get; set; }
        public string AmountInsuredCurrency { get; set; }
        public decimal AmountInsure { get; set; }
 
    }
}