using AutoMapper;
using ProEventos.Application.DTOs;
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
        private readonly IMapper _mapper;
        public EventoService(IRepositoryPersistence repository, IEventoPersistence eventoPersistence, IMapper mapper)
        {
            _repository = repository;
            _eventoPersistence = eventoPersistence;
            _mapper = mapper;
        }
        public async Task<EventoDto> AddEventos(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);

                _repository.Add(evento);

                if (await _repository.SaveChangesAsync())
                {
                   var eventoResult = await _eventoPersistence.GetEventoByIdAsync(evento.Id, false);

                    return _mapper.Map<EventoDto>(eventoResult);
                }
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

                _repository.Delete(evento);

                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<EventoDto> UpdateEvento(int id, EventoDto model)
        {
            try
            {             
                var evento = await _eventoPersistence.GetEventoByIdAsync(id, false);

                if (evento == null)
                    return null;

                model.Id = evento.Id;

                _mapper.Map(model, evento);

                _repository.Update(evento);

                if (await _repository.SaveChangesAsync())
                {
                   var eventoResult = await _eventoPersistence.GetEventoByIdAsync(model.Id, false);
                   return _mapper.Map<EventoDto>(eventoResult);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int id, bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetEventoByIdAsync(id, incluirPalestrante);
                if(eventos == null)
                    return null;

                var result = _mapper.Map<EventoDto>(eventos);   

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosAsync(incluirPalestrante);

                if(eventos == null)
                    return null;
                
                var result = _mapper.Map<EventoDto[]>(eventos);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetEventosByTemaAsync(string tema, bool incluirPalestrante = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetEventosByTemaAsync(tema, incluirPalestrante);

                if(eventos == null)
                    return null;
                
                var result = _mapper.Map<EventoDto[]>(eventos);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
