using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Models.Bling
{
    public class VencimentoClass
    {
            [JsonPropertyName("tipo")]
            public int tipo { get; set; }

            [JsonPropertyName("dia")]
            public int dia { get; set; }

            [JsonPropertyName("periodicidade")]
            public int periodicidade { get; set; }


        
    }
}
