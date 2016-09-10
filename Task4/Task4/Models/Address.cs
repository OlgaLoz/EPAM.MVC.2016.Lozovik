using System.Web.Mvc;
using Task4.Infrastructure;

namespace Task4.Models
{
    [ModelBinder(typeof(AddressModelBinder))]
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string AdressSummary { get; set; }
    }
}