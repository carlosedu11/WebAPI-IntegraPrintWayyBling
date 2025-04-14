using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Models.PrintWayy
{
    public class IncreaseModel
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }
    }
}
