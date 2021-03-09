using DonationData.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationData.Repository
{
    public class DonationRepository
    {
        private readonly DonationDBContext _context;

        public DonationRepository(DonationDBContext context)
        {
            _context = context;
        }

        public async Task<List<DonationEO>> GetAll()
        {
          return await _context.Donations.ToListAsync();
        }
        public async Task<int> Create(DonationEO entity)
        {
            var t = _context.Donations.Add(entity);
            await _context.SaveChangesAsync();
            return t.Entity.Id;
        }

        public async Task<int> Update(DonationEO donation)
        {
            var donationEO = _context.Donations.FirstOrDefault(x => x.Id ==donation.Id);
             _context.Entry(donationEO).CurrentValues.SetValues(donation);
            await _context.SaveChangesAsync();
            return donationEO.Id;
        }
    }
}
