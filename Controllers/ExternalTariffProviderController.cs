using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace External_Tariff_Provider.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalTariffProviderController : ControllerBase
    {
        private readonly ILogger<ExternalTariffProviderController> _logger;
        public ExternalTariffProviderController(ILogger<ExternalTariffProviderController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetExternalTariff")]
        public IEnumerable<ExternalTariff> Get(int Consumption)
        {
            List<ExternalTariff> externalTariff = new List<ExternalTariff>();
            if (Consumption != 0)
            {
                //Type 1 - Basic electricity tariff
                float baseAnnualCosts = (5 * 12) + (Consumption * 22 / 100);
                externalTariff.Add(new ExternalTariff
                {
                    TariffName = "Basic electricity tariff",
                    Type = 1,
                    BaseCost = 5,
                    AdditionalKwhCost = 22,
                    AnnualCosts = $"{baseAnnualCosts} €"
                });

                //Type 2 - Packaged tariff
                float packagedAnnualCosts = Consumption< 4000 ? 800 : 800 + ((Consumption - 4000) * 30/100);
                externalTariff.Add(new ExternalTariff
                {
                    TariffName = "Packaged tariff",
                    Type = 2,
                    IncludedKwh = 4000,
                    BaseCost = 800,
                    AdditionalKwhCost = 30,
                    AnnualCosts = $"{packagedAnnualCosts} €"
                });
            }
            return externalTariff;
        }
    }
}
