using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; } = null!;

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}
