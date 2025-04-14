using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Models.PrintWayy
{
    public class PendencyModel
    {
        [JsonPropertyName("printerId")]
        public string PrinterId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("partTimeStartDate")]
        public DateTime PartTimeStartDate { get; set; }

        [JsonPropertyName("partTimeEndDate")]
        public DateTime PartTimeEndDate { get; set; }

        [JsonPropertyName("communicationFailureDaysCount")]
        public int CommunicationFailureDaysCount { get; set; }
    }
}
