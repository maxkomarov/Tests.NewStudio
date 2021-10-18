using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Tests.NewStudio.Interfaces;
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
            //Использование здесь источника данных напрямую - только как заглушка. Чтобы можно было проверить работоспособность АПИ
            ICurrencyRateStorage storage = new CurrencyRatesStorage();
            
            return storage.GetAll().Select(currencyRate => new ViewModels.CurrencyRate(currencyRate));
        }
    }
}
