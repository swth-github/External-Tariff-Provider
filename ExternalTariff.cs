namespace External_Tariff_Provider
{
    public class ExternalTariff
    {
        public string? TariffName { get; set; }
        public string? AnnualCosts { get; set; }

        public int Type { get; set; }
        public int BaseCost { get; set; }
        public int AdditionalKwhCost { get; set; }
        public int IncludedKwh { get; set; }
    }
}
