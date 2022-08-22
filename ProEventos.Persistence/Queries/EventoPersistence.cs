using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.IQueries;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Queries
{
    public class EventoPersistence : IEventoPersistence
    {
        private readonly ProEventosContext _context;
        public EventoPersistence(ProEventosContext context)
        {
            _context = context;
            //Linha abaixo trasforma todos os get's em AsNoTracking()
           //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Evento> GetEventoByIdAsync(int id, bool incluirPalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
           .Include(x => x.Lotes)
           .Include(x => x.RedeSociais);

            if (incluirPalestrante)
                query = query.Include(x => x.PalestrantesEventos)
                             .ThenInclude(x => x.Palestrantes);

            query = query.AsNoTracking().OrderBy(x => x.Id)
                         .Where(x => x.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante)
        {
           IQueryable<Evento> query = _context.Eventos
                                         .Include(x => x.Lotes)
                                         .Include(x => x.RedeSociais);

           if (incluirPalestrante)
                query = query.Include(x => x.PalestrantesEventos)
                             .ThenInclude(x => x.Palestrantes);

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetEventosByTemaAsync(string tema, bool incluirPalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
                       .Include(x => x.Lotes)
                       .Include(x => x.RedeSociais);

             if (incluirPalestrante)
                  query = query.Include(x => x.PalestrantesEventos)
                               .ThenInclude(x => x.Palestrantes);

             query = query.AsNoTracking().OrderBy(x => x.Id)
                          .Where(x => x.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}
