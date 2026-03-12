using BikeRoubada.Business.Models;


namespace BikeRoubada.Business.Interfaces
{
    public interface ILocalizacaoService : IDisposable
    {
        Task<Localizacao?> Adicionar(Localizacao localizacao);
        Task<Localizacao?> Atualizar(Localizacao localizacao);
        Task Remover (Guid id);
    }
}
