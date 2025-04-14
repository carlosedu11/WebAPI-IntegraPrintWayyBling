using System.Diagnostics.Contracts;
using System.Reflection;
using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Models.PrintWayy
{
    public class RootFechamentoModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("documentNumber")]
        public int DocumentNumber { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("totalValue")]
        public double TotalValue { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("totalPagesBlackAndWhite")]
        public int TotalPagesBlackAndWhite { get; set; }

        [JsonPropertyName("totalPagesColor")]
        public int TotalPagesColor { get; set; }

        [JsonPropertyName("totalPagesScan")]
        public int TotalPagesScan { get; set; }

        [JsonPropertyName("customer")]
        public CustomerModel Customer { get; set; }

        [JsonPropertyName("contract")]
        public ContractModel Contract { get; set; }

        [JsonPropertyName("printers")]
        public List<PrinterModel> Printers { get; set; }

        [JsonPropertyName("sharedCosts")]
        public List<SharedCostModel> SharedCosts { get; set; }

        [JsonPropertyName("fixedCosts")]
        public List<FixedCostModel> FixedCosts { get; set; }

        [JsonPropertyName("pendencies")]
        public List<PendencyModel> Pendencies { get; set; }

        [JsonPropertyName("increases")]
        public List<IncreaseModel> Increases { get; set; }

        [JsonPropertyName("discounts")]
        public List<DiscountModel> Discounts { get; set; }
    }
}
