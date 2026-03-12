using BikeRoubada.Business.Interfaces;
using BikeRoubada.Business.Models;
using BikeRoubada.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BikeRoubada.Data.Repository
{
    public class LocalizacaoRepository : Repository<Localizacao>, ILocalizacaoRepository
    {
        public LocalizacaoRepository(AppDbContext context) : base(context)
        {
        }


    }
}
