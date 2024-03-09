using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Cinema? Cinema { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
    }
}
