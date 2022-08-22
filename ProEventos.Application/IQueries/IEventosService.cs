using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.IQueries
{
    public interface IEventosService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEvento(int id, Evento model);
        Task<bool> DeleteEvento(int id);

        Task<Evento[]> GetEventosByTemaAsync(string tema, bool incluirPalestrante = false);
        Task<Evento> GetEventoByIdAsync(int id, bool incluirPalestrante = false);
        Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante = false);
    }
}
