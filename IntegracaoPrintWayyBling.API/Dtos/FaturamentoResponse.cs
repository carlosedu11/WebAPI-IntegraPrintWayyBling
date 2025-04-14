using IntegracaoPrintWayyBling.API.Models.PrintWayy;
using System.Text.Json.Serialization;

namespace IntegracaoPrintWayyBling.API.Dtos
{
    public class FaturamentoResponse
    {
        public int Count { get; set; }
        public List<DataModel> Data { get; set; }
    }
}
