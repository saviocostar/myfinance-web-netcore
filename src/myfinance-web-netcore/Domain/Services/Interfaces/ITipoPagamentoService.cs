using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain.Services.Interfaces
{
    public interface ITipoPagamentoService
    {
        List<TipoPagamentoModel> ListarRegistros();
    }
}