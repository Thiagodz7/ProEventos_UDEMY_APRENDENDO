using ProEventos.Application.DTOs;
using System.Threading.Tasks;

namespace ProEventos.Application.IQueries
{
    public interface IEventosService
    {
        Task<EventoDto> AddEventos(EventoDto model);
        Task<EventoDto> UpdateEvento(int id, EventoDto model);
        Task<bool> DeleteEvento(int id);

        Task<EventoDto[]> GetEventosByTemaAsync(string tema, bool incluirPalestrante = false);
        Task<EventoDto> GetEventoByIdAsync(int id, bool incluirPalestrante = false);
        Task<EventoDto[]> GetAllEventosAsync(bool incluirPalestrante = false);
    }
}
