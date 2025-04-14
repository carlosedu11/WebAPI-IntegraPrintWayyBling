using System.Net;
using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Models.PrintWayy.Clientes
{
    public class LocationModel
    {
        [JsonPropertyName("customerPlaceId")]
        public string customerPlaceId { get; set; }

        [JsonPropertyName("customerName")]
        public string customerName { get; set; }

        [JsonPropertyName("isNaturalPerson")]
        public bool isNaturalPerson { get; set; }

        [JsonPropertyName("businessName")]
        public string businessName { get; set; }

        [JsonPropertyName("cpf")]
        public string cpf { get; set; }

        [JsonPropertyName("cnpj")]
        public string cnpj { get; set; }

        [JsonPropertyName("address")]
        public AdressModel address { get; set; }

        [JsonPropertyName("departments")]
        public List<string> departments { get; set; }
    }
}
