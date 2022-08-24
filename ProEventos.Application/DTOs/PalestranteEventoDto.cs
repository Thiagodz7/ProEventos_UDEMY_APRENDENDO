namespace ProEventos.Application.DTOs
{
    public class PalestranteEventoDto
    {
        public int PalestranteId { get; set; }
        public PalestranteDto Palestrantes { get; set; }
        public int EventoId { get; set; }
        public EventoDto Eventos { get; set; }
    }
}
