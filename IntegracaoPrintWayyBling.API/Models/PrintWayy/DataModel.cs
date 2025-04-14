using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Models.PrintWayy
{
    public class DataModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("documentNumber")]
        public int DocumentNumber { get; set; }

        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }

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
    }
}
