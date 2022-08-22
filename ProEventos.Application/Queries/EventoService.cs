using ProEventos.Application.IQueries;
using ProEventos.Domain;
using ProEventos.Persistence.IQueries;
using System;
using System.Threading.Tasks;

namespace ProEventos.Application.Queries
{
    public class EventoService : IEventosService
    {
        private readonly IRepositoryPersistence _repository;
        private readonly IEventoPersistence _eventoPersistence;
        public EventoService(IRepositoryPersistence repository, IEventoPersistence eventoPersistence)
        {
            _repository = repository;
            _eventoPersistence = eventoPersistence;
        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _repository.Add<Evento>(model);
                if (await _repository.SaveChangesAsync())
                    return await _eventoPersistence.GetEventoByIdAsync(model.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int id)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(id, false);

                if (evento == null)
                    throw new Exception("Evento para Delete não foi encontrado.");

                _repository.Delete<Evento>(evento);

                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> UpdateEvento(int id, Evento model)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(id, false);

                if (evento == null)
                    return null;

                model.Id = evento.Id;

                _repository.Update(model);
                if (await _repository.SaveChangesAsync())
                    return await _eventoPersistence.GetEventoByIdAsync(model.Id, false);

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int id, bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetEventoByIdAsync(id, incluirPalestrante);

                if(eventos == null)
                    return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosAsync(incluirPalestrante);

                if(eventos == null)
                    return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetEventosByTemaAsync(string tema, bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetEventosByTemaAsync(tema, incluirPalestrante);

                if(eventos == null)
                    return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
