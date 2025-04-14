using IntegracaoPrintWayyBling.API.Models.Bling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegracaoPrintWayyBling.Models.Bling
{
    public class Cobranca
    {
        [JsonPropertyName("dataBase")]
        public string? dataBase { get; set; }

        [JsonPropertyName("contato")]
        public Contato? contato { get; set; }

        [JsonPropertyName("vencimento")]
        public VencimentoClass? vencimento { get; set; }
    }
}
