using IntegracaoPrintWayyBling.API.Dtos;
using IntegracaoPrintWayyBling.API.Models.PrintWayy;

namespace IntegracaoPrintWayyBling.API.Interfaces.PrintWayy.Fechamentos
{
    public interface IPrintWayyApiFinanceiro
    {
        Task<ResponseGenerico<FechamentoModel>> BuscarTodosFechamentos();
        Task<ResponseGenerico<RootFechamentoModel>> BuscarFechamentoId(string id);
        Task<ResponseGenerico<FechamentoModel>> BuscarTodosFechamentosPorStatus();

    }
}
