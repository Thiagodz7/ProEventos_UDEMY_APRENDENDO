using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.DTOs
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DtEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(50, MinimumLength = 3, ErrorMessage = "Intervalo do campo {0} permitido de 3 a 50 caracteres.")]
        public string Tema { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"),
            Range(1, 120000, ErrorMessage ="{0} Não pode ser maior 120000 e menor que 1")]
        public int QtdPessoas { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", 
            ErrorMessage ="Não é uma imagem válida. (gif, jpg, jpeg,bmp ou png)")]
        public string ImagemURL { get; set; }

        [Required(ErrorMessage ="O Campo {0} é obrigatório"), 
            Phone(ErrorMessage ="O campo {0} está inválido!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"), Display(Name ="e-mail"),
            EmailAddress(ErrorMessage = "O campo {0} precisa ser válido!")]
        public string Email { get; set; }

        public IEnumerable<RedeSocialDto> RedeSociais { get; set; }

        public IEnumerable<LoteDto> Lotes { get; set; }

        public IEnumerable<PalestranteEventoDto> PalestrantesEventos { get; set; }
    }
}
