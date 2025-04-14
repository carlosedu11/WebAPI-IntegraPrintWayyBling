using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegracaoPrintWayyBling.Models.Bling
{
    public class Desconto
    {
        [JsonPropertyName("valor")]
        public float valor { get; set; }

        [JsonPropertyName("dataFim")]
        public string? dataFim { get; set; }
    }
}
