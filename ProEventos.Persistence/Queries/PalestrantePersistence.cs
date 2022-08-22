using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.IQueries;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Queries
{
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private readonly ProEventosContext _context;
        public PalestrantePersistence(ProEventosContext context)
        {
            _context = context;
        }
        public async Task<Palestrante> GetAllPalestranteByIdAsync(int id, bool incluirPalestrantes = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                               .Include(x => x.RedeSociais);

            if (incluirPalestrantes)
                query = query.Include(x => x.PalestrantesEventos)
                             .ThenInclude(x => x.Eventos);

            query = query.AsNoTracking().OrderBy(x => x.Id)
                         .Where(x => x.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirPalestrantes)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                                     .Include(x => x.RedeSociais);
                                                     
            if (incluirPalestrantes)
                query = query.Include(x => x.PalestrantesEventos)
                             .ThenInclude(x => x.Eventos);

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluirPalestrantes = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                    .Include(x => x.RedeSociais);

            if (incluirPalestrantes)
                query = query.Include(x => x.PalestrantesEventos)
                             .ThenInclude(x => x.Eventos);

            query = query.AsNoTracking().OrderBy(x => x.Id)
                         .Where(x => x.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}
