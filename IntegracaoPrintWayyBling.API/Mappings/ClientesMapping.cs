using AutoMapper;
using IntegracaoPrintWayyBling.API.Dtos;
using IntegracaoPrintWayyBling.API.Models.PrintWayy.Clientes;

namespace IntegracaoPrintWayyBling.API.Mappings
{
    public class ClientesMapping:Profile
    {
        public ClientesMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<RootClienteResponse, RootClienteModel>();
            CreateMap<RootClienteModel, RootClienteResponse>();
        }
        
    }
}
