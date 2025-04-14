using IntegracaoPrintWayyBling.API.Dtos;
using IntegracaoPrintWayyBling.API.Interfaces.PrintWayy.Clientes;
using IntegracaoPrintWayyBling.API.Interfaces.PrintWayy.Fechamentos;
using IntegracaoPrintWayyBling.API.Models.PrintWayy;
using IntegracaoPrintWayyBling.API.Models.PrintWayy.Clientes;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.ResponseCompression;
using System.ComponentModel;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace IntegracaoPrintWayyBling.API.Rest
{
    public class PrintWayyRest : IPrintWayyApiFinanceiro, IPrintWayyApiClientes
    {
        private readonly HttpClient _httpClient;

        public PrintWayyRest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseGenerico<RootFechamentoModel>> BuscarFechamentoId(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.printwayy.com/devices/v1/invoices/{id}");
            string apiKey = "27A08260-6CE0-4152-9030-0151400BC00E";

            var response = new ResponseGenerico<RootFechamentoModel>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("printwayy-key", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responsePrintWayyApi = await client.SendAsync(request);
                var conteudoResp = await responsePrintWayyApi.Content.ReadAsStringAsync();
                var objectResponse = JsonSerializer.Deserialize<RootFechamentoModel>(conteudoResp);

                if (responsePrintWayyApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responsePrintWayyApi.StatusCode;
                    response.DadosRetorno = objectResponse;
                }
                else
                {
                    response.CodigoHttp = responsePrintWayyApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(conteudoResp);
                }
                return response;

            }
        }


        public async Task<ResponseGenerico<FechamentoModel>> BuscarTodosFechamentos()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.printwayy.com/devices/v1/invoices");
            string apiKey = "27A08260-6CE0-4152-9030-0151400BC00E";


            var response = new ResponseGenerico<FechamentoModel>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("printwayy-key", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responsePrintWayyApi = await client.SendAsync(request);
                var contentResp = await responsePrintWayyApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<FechamentoModel>(contentResp);

                if (responsePrintWayyApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responsePrintWayyApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responsePrintWayyApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
                return response;


            }
        }


        public async Task<ResponseGenerico<FechamentoModel>> BuscarTodosFechamentosPorStatus()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.printwayy.com/devices/v1/invoices");
            string apiKey = "27A08260-6CE0-4152-9030-0151400BC00E";


            var response = new ResponseGenerico<FechamentoModel>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("printwayy-key", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responsePrintWayyApi = await client.SendAsync(request);
                var contentResp = await responsePrintWayyApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<FechamentoModel>(contentResp);
                List<DataModel> listaFrozen = new List<DataModel>();

                if (responsePrintWayyApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responsePrintWayyApi.StatusCode;
                    response.DadosRetorno = objResponse;

                    foreach (var fechamento in response.DadosRetorno.Data)
                    {
                        if (fechamento.Status == "processing")
                        {
                            listaFrozen.Add(fechamento);
                            // responseDataModel.DadosRetorno = fechamento;
                        }
                    }
                    response.DadosRetorno.Data = listaFrozen;
                    Console.WriteLine($"{response.DadosRetorno.Data.Count()}");
                    Console.WriteLine($"Contratos do PrintWayy");
                    foreach (var fechamento in response.DadosRetorno.Data)
                    {
                        Console.Write($"ID: {fechamento.Id}");
                        Console.WriteLine();
                        Console.Write($"Nome: {fechamento.Customer.Name}");
                        Console.WriteLine();
                        Console.Write($"Número do documento: {fechamento.DocumentNumber}");
                        Console.WriteLine();
                        Console.Write($"Total de Páginas: {fechamento.TotalPagesBlackAndWhite}");
                        Console.WriteLine();
                        Console.Write($"Total de Páginas Cor: {fechamento.TotalPagesColor}");
                        Console.WriteLine();
                        Console.Write($"Total de Páginas Scan: {fechamento.TotalPagesScan}");
                        Console.WriteLine();
                        Console.Write($"Valor Total: {fechamento.TotalValue}");
                        Console.WriteLine();
                        Console.Write($"Status: {fechamento.Status}");
                        Console.WriteLine();
                        Console.WriteLine("---------------//-------------");
                        Console.WriteLine();

                    };
                }
                else
                {
                    response.CodigoHttp = responsePrintWayyApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
                return response;

            }


        }

        public async Task<ResponseGenerico<RootClienteModel>> BuscarTodosClientes()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.printwayy.com/devices/v1/customers");
            var apiKey = "27A08260-6CE0-4152-9030-0151400BC00E";

            var response = new ResponseGenerico<RootClienteModel>();

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("printwayy-key", apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var responsePrintWayyApi = await _httpClient.SendAsync(request);
            var contentResponse = await responsePrintWayyApi.Content.ReadAsStringAsync();
            var objResponse = JsonSerializer.Deserialize<RootClienteModel>(contentResponse);

            if(responsePrintWayyApi.IsSuccessStatusCode)
            {
                response.CodigoHttp = responsePrintWayyApi.StatusCode;
                response.DadosRetorno = objResponse;
            }
            else
            {
                response.CodigoHttp = responsePrintWayyApi.StatusCode;
                response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
            }

            return response;


        }
    }
}
