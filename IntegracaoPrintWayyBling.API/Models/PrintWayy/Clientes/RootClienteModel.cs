using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Models.PrintWayy.Clientes
{
    public class RootClienteModel
    {
        [JsonPropertyName("count")]
        public int count { get; set; }

        [JsonPropertyName("data")]
        public List<DatumModel> data { get; set; }
    }
}
