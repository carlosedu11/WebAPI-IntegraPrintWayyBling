using IntegracaoPrintWayyBling.API.Interfaces;
using IntegracaoPrintWayyBling.API.Models;
using IntegracaoPrintWayyBling.API.Models.Bling;
using IntegracaoPrintWayyBling.Models.Bling;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace IntegracaoPrintWayyBling.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FechamentoController : ControllerBase
    {
        public readonly IFechamentoService _fechamentoService;

        public FechamentoController(IFechamentoService fechamentoService)
        {
            _fechamentoService = fechamentoService;
        }

        [HttpGet("GetAllFechamentos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> BuscarFechamentos()
        {
            var response = await _fechamentoService.BuscarFechamentos();

            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
                
            }  
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }
        }

        [HttpGet("GetStatusFechamento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> BuscarFechamentosPorStatus()
        {
            var response = await _fechamentoService.BuscarTodosFechamentosPorStatus();

            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);

            }
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }
        }

        [HttpGet("GetFechamentoId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> BuscarFechamentoId(string id)
        {
            var response = await _fechamentoService.BuscarFechamentoId(id);

            if(response.CodigoHttp == HttpStatusCode.OK)
            {

                return Ok(response.DadosRetorno);
            }
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }
        }

        /*
        [HttpPost("CreateContractForBling/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateTransformarBling(string id)
        {
            var response = await _fechamentoService.BuscarFechamentoId(id);

            Iss iss = new Iss();
            iss.descontar = false;
            iss.aliquota = 2.5f;

            Item item = new Item();
            item.codigoServico = "14.13";
            item.produto = new Produto() { id = 9659733289 };

            NotaFiscal nota = new NotaFiscal();
            nota.mes = 2;
            nota.gerar = 1;
            nota.descontarImpostoRenda = 1;
            nota.texto = "Exemplo de texto.";
            nota.cfop = "5.556";
            nota.iss = iss;
            nota.item = item;

            FormaPagamento formaPagamento = new FormaPagamento();
            formaPagamento.id = 9659733289;

            ContaContabil contaContabil = new ContaContabil();
            contaContabil.id = 9659733289;

            Desconto desconto = new Desconto();
            desconto.valor = 4.99f;
            desconto.dataFim = "2025-12";


            Categoria categoria = new Categoria();
            categoria.id = 9659733289;

            Contato contato = new Contato();
            contato.id = 9659733289;

            VencimentoClass vencimento = new VencimentoClass();
            vencimento.tipo = 1;
            vencimento.dia = 11;
            vencimento.periodicidade = 1;

            Cobranca cobranca = new Cobranca();
            cobranca.dataBase = "2025-03-29";
            cobranca.contato = contato;
            cobranca.vencimento = vencimento;

            Vendedor vendedor = new Vendedor();
            vendedor.id = 9659733289;
            vendedor.comissao = new Comissao() { aliquota = 0.5f, numeroParcelas = 1 };


            Root root = new Root();
            root.descricao = response.DadosRetorno.Id;
            root.data = "2025-03-29";
            root.numero = "25";
            root.valor = (float)59.99;
            root.situacao = 1;
            root.contato = contato;
            root.dataFim = "2025-12";
            root.tipoManutencao = 1;
            root.emitirOrdemServico = false;
            root.observacoes = response.DadosRetorno.Id;
            root.vendedor = vendedor;
            root.categoria = categoria;
            root.desconto = desconto;
            root.contaContabil = contaContabil;
            root.formaPagamento = formaPagamento;
            root.notaFiscal = nota;
            root.cobranca = cobranca;
            root.vencimento = vencimento;


            if (response.CodigoHttp == HttpStatusCode.OK)
            {

                string jsonString = JsonConvert.SerializeObject(root);
                //var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                string baseUrlBling = "https://api.bling.com.br/Api/v3/contratos";
                string tokenBling = "93745efa4f05a44f45cc5034780b13c56fa1d257";

                var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrlBling}")
                {
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
                };


                using (var client = new HttpClient())
                { 

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenBling);


                    var responseBlingApi = await client.SendAsync(request);
                    var conteudoResponse = await responseBlingApi.Content.ReadAsStringAsync();
                    //var objResponse = JsonSerializer.Deserialize<Root>(conteudoResponse);

                    return Ok(conteudoResponse);
                    
                    }
            }
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }

        }
        */

        [HttpPost("PostContratoStatusBling")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateContratoStatusBling()
        {
            var response = await _fechamentoService.CreateTransformarStatusBling();

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("teste");
            }

        }    
    }
}
