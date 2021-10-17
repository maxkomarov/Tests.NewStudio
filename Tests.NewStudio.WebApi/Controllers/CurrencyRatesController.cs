using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Tests.NewStudio.Interfaces;
using Tests.NewStudio.Models;
using Tests.NewStudio.Services;

namespace Tests.NewStudio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyRatesController : ControllerBase
    {
        private readonly ILogger<CurrencyRatesController> _logger;

        public CurrencyRatesController(ILogger<CurrencyRatesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ViewModels.CurrencyRate> GetAll()
        {
            ICurrencyRateStorage storage = new CurrencyRatesStorage();
            storage.Add(new CurrencyRate(new Currency("RUR"), new Currency("USD"), 70));
            storage.Add(new CurrencyRate(new Currency("RUR"), new Currency("EUR"), 80));
            storage.Add(new CurrencyRate(new Currency("RUR"), new Currency("GBP"), 90));
            return storage.GetAll().Select(currencyRate => new ViewModels.CurrencyRate(currencyRate));
        }
    }
}
