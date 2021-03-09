using DonationData.DB;
using DonationData.Repository;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DonationAPI.Services
{
    public class DonationService : IDonationService
    {
        private readonly DonationRepository _donationRepository;
        public DonationService(DonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }
        public async Task<int> CreateDonation(DonationEO donation)
        {
            if(donation.Amount>10000)
            {
                try
                {
                    SendEmail();
                }
                catch (Exception ex)
                {

                }
                
            }
            return await _donationRepository.Create(donation);
        }

        private void SendEmail()
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("email"));
            email.To.Add(MailboxAddress.Parse("email"));
            email.Subject = "התקבלה תרומה חדשה";
            email.Body = new TextPart(TextFormat.Plain) { Text = "התקבלה תרומה בסך הגדול מ 1000 ש\"ח" };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, true);
            smtp.Authenticate("email", "password");
            smtp.Send(email);
            smtp.Disconnect(true);
            smtp.Dispose();



        }

        public async Task<List<DonationEO>> GetList()
        {
            return await _donationRepository.GetAll();
        }

        public async Task<int> UpdateDonation(DonationEO donation)
        {
            return await _donationRepository.Update(donation);
        }
    }
}
