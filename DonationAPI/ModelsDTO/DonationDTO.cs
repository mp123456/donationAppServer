using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationAPI.ModelsDTO
{
    public class DonationDTO
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public int CountrtType { get; set; }
        public string Purpose { get; set; }
        public string Conditions { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public decimal ConversionRate { get; set; }
        public string UserId { get; set; }
    }
}
