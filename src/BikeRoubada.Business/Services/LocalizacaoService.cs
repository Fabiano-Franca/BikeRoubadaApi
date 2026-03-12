using BikeRoubada.Business.Interfaces;
using BikeRoubada.Business.Models;
using BikeRoubada.Business.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRoubada.Business.Services
{
    public class LocalizacaoService : BaseService, ILocalizacaoService
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;
        public LocalizacaoService(ILocalizacaoRepository localizacaoRepository, INotificador notificador) : base(notificador)
        {
            _localizacaoRepository = localizacaoRepository;
        }
        public async Task<Localizacao?> Adicionar(Localizacao localizacao)
        {
            localizacao.Cep = localizacao.Cep?.Replace("-", "").Trim();

            if (!ExecutarValidacao(new LocalizacaoValidation(), localizacao))
            {
                return null;
            }
 
            return await _localizacaoRepository.Adicionar(localizacao);
        }

        public async Task<Localizacao?> Atualizar(Localizacao localizacao)
        {
            if (!ExecutarValidacao(new LocalizacaoValidation(), localizacao))
            {
                return null;
            }

            return await _localizacaoRepository.Atualizar(localizacao);
        }

        public void Dispose()
        {
            _localizacaoRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
           await _localizacaoRepository.Remover(id);
        }
    }
}
