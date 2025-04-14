using IntegracaoPrintWayyBling.API.Dtos;
using IntegracaoPrintWayyBling.API.Models.PrintWayy.Clientes;

namespace IntegracaoPrintWayyBling.API.Interfaces.PrintWayy.Clientes
{
    public interface IPrintWayyApiClientes
    {
        Task<ResponseGenerico<RootClienteModel>> BuscarTodosClientes();

    }
}
