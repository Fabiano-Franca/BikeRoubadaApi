using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRoubada.Business.Models
{
    public class Localizacao : Entity
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string? Cep { get; set; }
        public DateTime DataCadastro { get; set; }
        public Point Coordenadas { get; set; }
        public Roubo? Roubo { get; set; }
    }
}
