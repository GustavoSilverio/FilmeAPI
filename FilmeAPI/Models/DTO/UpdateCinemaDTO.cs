using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models.DTO
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
    }
}
