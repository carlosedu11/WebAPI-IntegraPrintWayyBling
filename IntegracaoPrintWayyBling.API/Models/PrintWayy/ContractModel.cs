using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Models.PrintWayy
{
    public class ContractModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("identification")]
        public string Identification { get; set; }
    }
}
