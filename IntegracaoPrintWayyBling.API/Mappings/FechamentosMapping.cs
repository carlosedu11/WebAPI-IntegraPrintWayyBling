using AutoMapper;
using IntegracaoPrintWayyBling.API.Dtos;
using IntegracaoPrintWayyBling.API.Models.PrintWayy;

namespace IntegracaoPrintWayyBling.API.Mappings
{
    public class FechamentosMapping:Profile
    {
        public FechamentosMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<FaturamentoResponse, FechamentoModel>();
            CreateMap<FechamentoModel, FaturamentoResponse>();
            CreateMap<RootFechamentoResponse, RootFechamentoModel>();
            CreateMap<RootFechamentoModel, RootFechamentoResponse>();
            CreateMap<DataModelResponse, DataModel>();
            CreateMap<DataModel, DataModelResponse>();

        }
    }
}
