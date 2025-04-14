using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegracaoPrintWayyBling.Models.Bling
{
    public class Item
    {
        [JsonPropertyName("codigoServico")]
        public string? codigoServico { get; set; }

        [JsonPropertyName("produto")]
        public Produto? produto { get; set; }
    }
}
