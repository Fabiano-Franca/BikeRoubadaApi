using BikeRoubada.Api.AuxiliaryModels;
using BikeRoubada.Api.ViewModels.Arquivo;
using BikeRoubada.Api.ViewModels.Roubo;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BikeRoubada.Api.ViewModels.Bicicleta
{
    public class BicicletaBuscaViewModel
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Serial { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Descricao { get; set; }
        public string? Detalhes { get; set; }
        [Required(ErrorMessage = "A localização de cadastro é obrigatória para fins de segurança.")]
        public SimplePoint? LocalizacaoCadastro { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid IdEndereco { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid IdUsuario { get; set; }
        public List<RouboApenasViewModel>? Roubos { get; set; }
        public List<ArquivoApenasViewModel>? Arquivos { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime DataCadastro { get; set; }
    }
}
