using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegracaoPrintWayyBling.Models.Bling
{
    public class Comissao
    {
        [JsonPropertyName("aliquota")]
        public float aliquota { get; set; }

        [JsonPropertyName("numeroParcelas")]
        public int numeroParcelas { get; set; }
    }
}
