using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Models.PrintWayy
{
    public class CounterModel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("startCounter")]
        public int StartCounter { get; set; }

        [JsonPropertyName("endCounter")]
        public int EndCounter { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("totalCost")]
        public double TotalCost { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("costDescription")]
        public string CostDescription { get; set; }
    }
}
