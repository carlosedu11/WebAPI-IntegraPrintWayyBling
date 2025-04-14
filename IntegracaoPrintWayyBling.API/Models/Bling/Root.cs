using IntegracaoPrintWayyBling.API.Models.Bling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegracaoPrintWayyBling.Models.Bling
{
    public class Root
    {

        [JsonPropertyName("descricao")]
        public string? descricao { get; set; }

        [JsonPropertyName("data")]
        public string? data { get; set; }

        [JsonPropertyName("numero")]
        public string? numero { get; set; }

        [JsonPropertyName("valor")]
        public float valor { get; set; }

        [JsonPropertyName("situacao")]
        public int situacao { get; set; }

        [JsonPropertyName("contato")]
        public Contato? contato { get; set; }

        [JsonPropertyName("dataFim")]
        public string? dataFim { get; set; }

        [JsonPropertyName("tipoManutencao")]
        public int tipoManutencao { get; set; }

        [JsonPropertyName("emitirOrdemServico")]
        public bool emitirOrdemServico { get; set; }

        [JsonPropertyName("observacoes")]
        public string? observacoes { get; set; }

        [JsonPropertyName("vendedor")]
        public Vendedor? vendedor { get; set; }

        [JsonPropertyName("categoria")]
        public Categoria? categoria { get; set; }

        [JsonPropertyName("desconto")]
        public Desconto? desconto { get; set; }

        [JsonPropertyName("contaContabil")]
        public ContaContabil? contaContabil { get; set; }

        [JsonPropertyName("formaPagamento")]
        public FormaPagamento? formaPagamento { get; set; }

        [JsonPropertyName("notaFiscal")]
        public NotaFiscal? notaFiscal { get; set; }

        [JsonPropertyName("cobranca")]
        public Cobranca? cobranca { get; set; }

        [JsonPropertyName("vencimento")]
        public VencimentoClass? vencimento { get; set; }

    }
}
