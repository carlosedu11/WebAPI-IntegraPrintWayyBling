using IntegracaoPrintWayyBling.API.Dtos;
using IntegracaoPrintWayyBling.API.Models.PrintWayy.Clientes;

namespace IntegracaoPrintWayyBling.API.Interfaces
{
    public interface IClientesService
    {
        Task<ResponseGenerico<RootClienteResponse>> BuscarTodosClientes();
    }
}
