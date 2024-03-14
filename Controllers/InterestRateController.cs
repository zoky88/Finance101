using Finance101.Data;
using Finance101.Models;
using Finance101.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finance101.Controllers
{
    public class InterestRateController : Controller
    {
        private readonly DailyInterestRateService _dailyInterestRateService;
        private readonly Finance101Context _context;

        public InterestRateController(DailyInterestRateService dailyInterestRateService, Finance101Context context)
        {
            _dailyInterestRateService = dailyInterestRateService;
            _context = context;
        }


    }
}







