using System;

namespace ProEventos.Domain
{
    public class Lote
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DtInicio { get; set; }
        public DateTime? DtFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; }
        public Evento Eventos { get; set; }

    }
}
