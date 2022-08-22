using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Persistence.IQueries
{
    public interface IPalestrantePersistence
    {
        //Palestrantes
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluirPalestrantes);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirPalestrantes);
        Task<Palestrante> GetAllPalestranteByIdAsync(int id, bool incluirPalestrantes);
    }
}
