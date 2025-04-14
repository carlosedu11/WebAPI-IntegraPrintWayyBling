using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegracaoPrintWayyBling.Models.Bling
{
    public class Iss
    {
        [JsonPropertyName("descontar")]
        public bool descontar { get; set; }

        [JsonPropertyName("aliquota")]
        public float aliquota { get; set; }
    }
}
