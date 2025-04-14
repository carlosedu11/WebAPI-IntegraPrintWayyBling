using IntegracaoPrintWayyBling.API.Dtos;
using IntegracaoPrintWayyBling.API.Models;
using System.Globalization;

namespace IntegracaoPrintWayyBling.API.Interfaces
{
    public interface IFechamentoService
    {
        Task<ResponseGenerico<FaturamentoResponse>> BuscarFechamentos();
        Task<ResponseGenerico<FaturamentoResponse>> BuscarTodosFechamentosPorStatus();
        Task<List<string>> CreateTransformarStatusBling();
        Task<ResponseGenerico<RootFechamentoResponse>> BuscarFechamentoId(string id);

    }
}
