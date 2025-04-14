using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegracaoPrintWayyBling.Models.Bling
{
    public class NotaFiscal
    {
        [JsonPropertyName("mes")]
        public int mes { get; set; }

        [JsonPropertyName("gerar")]
        public int gerar { get; set; }

        [JsonPropertyName("descontarImpostoRenda")]
        public int descontarImpostoRenda { get; set; }

        [JsonPropertyName("texto")]
        public string texto { get; set; }

        [JsonPropertyName("cfop")]
        public string cfop { get; set; }

        [JsonPropertyName("iss")]
        public Iss iss { get; set; }

        [JsonPropertyName("item")]
        public Item item { get; set; }

    }

}
