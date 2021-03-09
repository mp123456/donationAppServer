using DonationData.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationAPI.Services
{
    public interface IDonationService
    {
        Task<List<DonationEO>> GetList();
        Task<int> CreateDonation(DonationEO donation);
        Task<int> UpdateDonation(DonationEO donation);


    }
}
