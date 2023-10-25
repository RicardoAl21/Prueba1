using AutoMapper;
using BackApi.DTO;
using BackApi.Models;
using BackApi.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoservice;
        private readonly IMapper _mapper;

        public DepartamentoController(IDepartamentoService departamentoService, IMapper mapper)
        {
            _mapper = mapper;
            _departamentoservice = departamentoService;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<DepartamentoDTO>>> Get()
        {
            var listaDepartamentos = await _departamentoservice.GetDepartamentos();
            var listaDepaDTO = _mapper.Map<List<DepartamentoDTO>>(listaDepartamentos);

            if (listaDepaDTO.Count > 0)
                return Ok(listaDepaDTO);
            else
                return NotFound();
        }
    }
}
