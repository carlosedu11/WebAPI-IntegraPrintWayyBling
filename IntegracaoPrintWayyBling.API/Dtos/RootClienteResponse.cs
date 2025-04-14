using IntegracaoPrintWayyBling.API.Models.PrintWayy.Clientes;
using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Dtos
{
    public class RootClienteResponse
    {
        [JsonPropertyName("count")]
        public int count { get; set; }

        [JsonPropertyName("data")]
        public List<DatumModel> data { get; set; }
    }
}
