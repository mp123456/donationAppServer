using AutoMapper;
using DonationAPI.ModelsDTO;
using DonationData.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationAPI.Mapper
{
    public class MappingDonation:Profile
    {
        public MappingDonation()
        {
            CreateMap<DonationDTO, DonationEO>().ReverseMap();
        }
    }
}
