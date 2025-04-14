using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegracaoPrintWayyBling.Models.Bling
{
    public class ContaContabil
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
    }
}
