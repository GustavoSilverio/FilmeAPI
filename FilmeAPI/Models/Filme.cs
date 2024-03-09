using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; internal set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(70, 600, ErrorMessage = "Mínimo de 70 minutos e máximo de 600 minutos")]
        public int Duracao { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}
