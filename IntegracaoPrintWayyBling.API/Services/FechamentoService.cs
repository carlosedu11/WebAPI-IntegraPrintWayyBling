using AutoMapper;
using IntegracaoPrintWayyBling.API.Dtos;
using IntegracaoPrintWayyBling.API.Interfaces;
using IntegracaoPrintWayyBling.API.Models.Bling;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using IntegracaoPrintWayyBling.Models.Bling;
using IntegracaoPrintWayyBling.API.Interfaces.PrintWayy.Fechamentos;

namespace IntegracaoPrintWayyBling.API.Services
{
    public class FechamentoService : IFechamentoService
    {
        private readonly IMapper _mapper;
        private readonly IPrintWayyApiFinanceiro _printWayyApi;
        private readonly IClientesService _clientesService;
        
        public FechamentoService(IMapper mapper, IPrintWayyApiFinanceiro printWayyApi, IClientesService clientesService)
        {
            _mapper = mapper;
            _printWayyApi = printWayyApi;
            _clientesService = clientesService;
        }

        public async Task<ResponseGenerico<RootFechamentoResponse>> BuscarFechamentoId(string id)
        {
            var fechamentoId = await _printWayyApi.BuscarFechamentoId(id);
            return _mapper.Map<ResponseGenerico<RootFechamentoResponse>>(fechamentoId);

        }

        public async Task<ResponseGenerico<FaturamentoResponse>> BuscarFechamentos()
        {
            var fechamento = await _printWayyApi.BuscarTodosFechamentos();
            return _mapper.Map<ResponseGenerico<FaturamentoResponse>>(fechamento);
        }

        public async Task<ResponseGenerico<FaturamentoResponse>> BuscarTodosFechamentosPorStatus()
        {
            var fechamento = await _printWayyApi.BuscarTodosFechamentosPorStatus();
            return _mapper.Map<ResponseGenerico<FaturamentoResponse>>(fechamento);
        }

        public async Task<List<string>> CreateTransformarStatusBling()
        {
            var responseFechamento = await _printWayyApi.BuscarTodosFechamentosPorStatus();
            var responseCliente = await _clientesService.BuscarTodosClientes();
            List<string> conteudoRetorno = new List<string>();

            for (int i = 0; i < responseFechamento.DadosRetorno.Data.Count(); i++)
            {
                for (int y = 0; y < responseCliente.DadosRetorno.data.Count(); y++)
                {
                    if (responseFechamento.DadosRetorno.Data[i].Customer.Name == responseCliente.DadosRetorno.data[y].name)
                    {
                        Iss iss = new Iss();
                        iss.descontar = false;
                        iss.aliquota = 0;

                        Item item = new Item();
                        item.codigoServico = "";
                        item.produto = new Produto() { id = 0 };

                        NotaFiscal nota = new NotaFiscal();
                        nota.mes = 1;
                        nota.gerar = 1;
                        nota.descontarImpostoRenda = 1;
                        nota.texto = "teste";
                        nota.cfop = "teste";
                        nota.iss = iss;
                        nota.item = item;

                        FormaPagamento formaPagamento = new FormaPagamento();
                        formaPagamento.id = responseCliente.DadosRetorno.data[y].customerCode;

                        ContaContabil contaContabil = new ContaContabil();
                        contaContabil.id = responseCliente.DadosRetorno.data[y].customerCode;

                        Desconto desconto = new Desconto();
                        desconto.valor = 0.0f;
                        desconto.dataFim = "";


                        Categoria categoria = new Categoria();
                        categoria.id = responseCliente.DadosRetorno.data[y].customerCode;

                        Contato contato = new Contato();
                        contato.id = responseCliente.DadosRetorno.data[y].customerCode;

                        VencimentoClass vencimento = new VencimentoClass();
                        vencimento.tipo = 1;
                        vencimento.dia = 11;
                        vencimento.periodicidade = 1;

                        Cobranca cobranca = new Cobranca();
                        cobranca.dataBase = "2025-03-29";
                        cobranca.contato = contato;
                        cobranca.vencimento = vencimento;

                        Vendedor vendedor = new Vendedor();
                        vendedor.id = 0;
                        vendedor.comissao = new Comissao() { aliquota = 0.0f, numeroParcelas = 0 };

                        Root root = new Root();
                        //var fechamento = await _printWayyApi.BuscarFechamentoId(response.DadosRetorno.Data[i].Id);
                        root.descricao = $"{responseFechamento.DadosRetorno.Data[i].Customer.Name} - DOC {responseFechamento.DadosRetorno.Data[i].DocumentNumber}"; ;
                        root.data = "2025-03-29";
                        root.numero = "25";
                        root.valor = (float)responseFechamento.DadosRetorno.Data[i].TotalValue;
                        root.situacao = 1;
                        root.contato = contato;
                        root.dataFim = "2025-12";
                        root.tipoManutencao = 1;
                        root.emitirOrdemServico = false;
                        root.observacoes = responseFechamento.DadosRetorno.Data[i].Id;
                        root.vendedor = vendedor;
                        root.categoria = categoria;
                        root.desconto = desconto;
                        root.contaContabil = contaContabil;
                        root.formaPagamento = formaPagamento;
                        root.notaFiscal = nota;
                        root.cobranca = cobranca;
                        root.vencimento = vencimento;

                        if (responseFechamento.CodigoHttp == HttpStatusCode.OK)
                        {

                            string jsonString = JsonConvert.SerializeObject(root);
                            //var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                            string baseUrlBling = "https://api.bling.com.br/Api/v3/contratos";
                            string tokenBling = "e8e10309591d86729e3b853983f5dfbbb82b87ef";

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
                                await Task.Delay(3000);
                                var conteudoResponse = await responseBlingApi.Content.ReadAsStringAsync();
                                conteudoRetorno.Add(conteudoResponse);
                                //var objResponse = JsonSerializer.Deserialize<Root>(conteudoResponse);

                                // return Ok(conteudoResponse);

                            }
                        }
                        else
                        {
                            return new List<string>();
                        }

                    }
                }   

            }
            return (conteudoRetorno);
        }


    }
}
