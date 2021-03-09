using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationData.DB
{
    public class DonationDBContext : DbContext
    {
        public DbSet<DonationEO> Donations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=C:/Users/meravp/source/repos/DonationAPI/DonationData/donation.db");
    }

    public class DonationEO
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public int CountrtType { get; set; }
        public string Purpose { get; set; }
        public string Conditions { get; set; }
        public string Currency { get; set; }
        public float Amount { get; set; }
        public float ConversionRate { get; set; }
    }

  
}
