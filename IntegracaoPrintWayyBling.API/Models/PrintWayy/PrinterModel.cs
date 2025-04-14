using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Models.PrintWayy
{
    public class PrinterModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("fixedCost")]
        public int FixedCost { get; set; }

        [JsonPropertyName("totalCost")]
        public double TotalCost { get; set; }

        [JsonPropertyName("additionalNote")]
        public string AdditionalNote { get; set; }

        [JsonPropertyName("location")]
        public LocationModel Location { get; set; }

        [JsonPropertyName("counters")]
        public List<CounterModel> Counters { get; set; }
    }
}
