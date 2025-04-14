using IntegracaoPrintWayyBling.API.Models.PrintWayy;
using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Dtos
{
    public class RootFechamentoResponse
    {

        public string Id { get; set; }

        public int DocumentNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double TotalValue { get; set; }

        public string Status { get; set; }

        public int TotalPagesBlackAndWhite { get; set; }

        public int TotalPagesColor { get; set; }

        public int TotalPagesScan { get; set; }

        public CustomerModel Customer { get; set; }

        public ContractModel Contract { get; set; }

        public List<PrinterModel> Printers { get; set; }

        public List<SharedCostModel> SharedCosts { get; set; }

        public List<FixedCostModel> FixedCosts { get; set; }

        public List<PendencyModel> Pendencies { get; set; }

        [JsonPropertyName("increases")]
        public List<IncreaseModel> Increases { get; set; }

        [JsonPropertyName("discounts")]
        public List<DiscountModel> Discounts { get; set; }
    }
}
