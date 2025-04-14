using System.Net;
using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Models.PrintWayy
{
    public class LocationModel
    {
        [JsonPropertyName("address")]
        public AdressModel Address { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }
    }
}
