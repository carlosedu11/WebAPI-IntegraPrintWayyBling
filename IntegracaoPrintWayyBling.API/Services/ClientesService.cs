using AutoMapper;
using IntegracaoPrintWayyBling.API.Dtos;
using IntegracaoPrintWayyBling.API.Interfaces;
using IntegracaoPrintWayyBling.API.Interfaces.PrintWayy.Clientes;

namespace IntegracaoPrintWayyBling.API.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IPrintWayyApiClientes _printWayyApiClientes;
        private readonly IMapper _mapper;
        public ClientesService(IMapper mapper,IPrintWayyApiClientes printWayyApiClientes)
        {
            _printWayyApiClientes = printWayyApiClientes;
            _mapper = mapper;
        }
        public async Task<ResponseGenerico<RootClienteResponse>> BuscarTodosClientes()
        {
            var cliente  = await _printWayyApiClientes.BuscarTodosClientes();
            return _mapper.Map<ResponseGenerico<RootClienteResponse>>(cliente);
        }
    }
}
