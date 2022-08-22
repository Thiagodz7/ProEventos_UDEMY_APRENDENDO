using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.IQueries
{
    public interface IEventoPersistence
    {
        //EVENTOS
        Task<Evento[]> GetEventosByTemaAsync(string tema, bool incluirPalestrante = false);
        Task<Evento> GetEventoByIdAsync(int id, bool incluirPalestrante = false);
        Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante = false);

    }
}
