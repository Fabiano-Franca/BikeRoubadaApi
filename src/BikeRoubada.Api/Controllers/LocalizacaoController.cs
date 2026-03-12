using AutoMapper;
using BikeRoubada.Api.ViewModels;
using BikeRoubada.Api.ViewModels.Endereco;
using BikeRoubada.Business.Interfaces;
using BikeRoubada.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BikeRoubada.Api.Controllers
{
    [Route("api/[controller]")]
    public class LocalizacaoController : MainController
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;
        private readonly ILocalizacaoService _localizacaoService;
        private readonly IMapper _mapper;

        public LocalizacaoController(ILocalizacaoRepository localizacaoRepository,
                                  ILocalizacaoService localizacaoService,
                                  IMapper mapper,
                                  INotificador notificador) : base(notificador)
        {
            _localizacaoRepository = localizacaoRepository;
            _localizacaoService = localizacaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalizacaoViewModel>>> ObterTodos()
        {
            return Ok(_mapper.Map<IEnumerable<LocalizacaoViewModel>>(await _localizacaoRepository.ObterTodos()));
        }

        [HttpGet("obter-por-id")]
        public async Task<ActionResult<LocalizacaoViewModel>> ObterPorId(Guid id)
        {
            return CustomResponse(HttpStatusCode.OK, _mapper.Map<LocalizacaoViewModel>(await _localizacaoRepository.ObterPorId(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(LocalizacaoViewModel localizacaoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var localizacao = await _localizacaoService.Adicionar(_mapper.Map<Localizacao>(localizacaoViewModel));

            return CustomResponse(System.Net.HttpStatusCode.Created, new { localizacao });
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(Guid id, LocalizacaoViewModel localizacaoViewModel)
        {
            if (id != localizacaoViewModel.Id)
            {
                NotificarErro("O parametro id é diferente do existente no objeto fornecido");
            }

            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var endereco = await _localizacaoService.Atualizar(_mapper.Map<Localizacao>(localizacaoViewModel));

            return CustomResponse(System.Net.HttpStatusCode.Created, new { endereco });
        }

        [HttpDelete]
        public async Task<ActionResult> Remover(Guid id)
        {
            await _localizacaoService.Remover(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }
    }
}
