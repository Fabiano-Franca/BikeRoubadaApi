using System.ComponentModel.DataAnnotations;
namespace BikeRoubada.Api.ViewModels
{
    public class LoginUserViewModel 
    {
        [Required(ErrorMessage = "o campo  {0} é obrigatóro")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {1} caracteres")]
        public string IdentificadorPessoal { get; set; }

        [Required(ErrorMessage = "o campo  {0} é obrigatóro")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
