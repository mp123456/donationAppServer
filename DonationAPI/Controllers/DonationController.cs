using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DonationAPI.ModelsDTO;
using DonationAPI.Services;
using DonationData.DB;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DonationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService _donationService;

        private readonly ILogger<DonationController> _logger;
        private readonly IMapper _mapper;
        public readonly IHttpContextAccessor _httpContextAccessor;

        public DonationController(ILogger<DonationController> logger, IDonationService donationService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _donationService = donationService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult> Get()
        {
            var list = await _donationService.GetList();
            var res = _mapper.Map<List<DonationDTO>>(list);
            return Ok(res);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add([FromBody] DonationDTO donation)
        {
            try
            {
                var dEO = _mapper.Map<DonationEO>(donation);
                var res = await _donationService.CreateDonation(dEO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "exception");
            }
           
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] DonationDTO donation)
        {
            try
            {
                string authToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                if(!IsAuthorized(donation,authToken))
                {
                    return Unauthorized();
                }
                var dEO = _mapper.Map<DonationEO>(donation);
                var res = await _donationService.UpdateDonation(dEO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "exception");
            }

        }

        private bool IsAuthorized(DonationDTO donation, string authToken)
        {
            if (donation.UserId == authToken)
            {
                return true;
            }
            return true;
        }
    }
}
