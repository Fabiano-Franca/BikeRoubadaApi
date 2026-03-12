using BikeRoubada.Api.AuxiliaryModels;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRoubada.Api.ViewModels
{
    public class LocalizacaoViewModel
    {

        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Estado { get; set; }
        public string? Cep { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public SimplePoint Coordenadas { get; set; }
        public DateTime DataCadastro { get; set; }


    }
}
