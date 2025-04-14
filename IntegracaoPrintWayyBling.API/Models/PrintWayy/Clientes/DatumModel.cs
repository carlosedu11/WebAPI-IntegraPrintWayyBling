using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Models.PrintWayy.Clientes
{
    public class DatumModel
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("installationKey")]
        public string installationKey { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime createdDate { get; set; }

        [JsonPropertyName("isNaturalPerson")]
        public bool isNaturalPerson { get; set; }

        [JsonPropertyName("cpf")]
        public string cpf { get; set; }

        [JsonPropertyName("cnpj")]
        public string cnpj { get; set; }

        [JsonPropertyName("mainLocation")]
        public string mainLocation { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("customerCode")]
        public string customerCode { get; set; }

        [JsonPropertyName("locations")]
        public List<LocationModel> locations { get; set; }
    }
}
