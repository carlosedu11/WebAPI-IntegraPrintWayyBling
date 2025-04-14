using IntegracaoPrintWayyBling.Models.Bling;
using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Models.Bling
{
    public class Vendedor
    {
        [JsonPropertyName("id")]
        public Int64 id { get; set; }

        [JsonPropertyName("comissao")]
        public Comissao comissao { get; set; }
    }
}
