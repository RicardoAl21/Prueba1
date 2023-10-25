using AutoMapper;
using BackApi.DTO;
using BackApi.Models;
using BackApi.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;
        private readonly IMapper _mapper;

        public CargoController(ICargoService cargoService, IMapper mapper)
        {
                  _mapper = mapper;
            _cargoService = cargoService;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<CargoDTO>>> Get()
        {
            var listaCargos = await _cargoService.GetCargos();
            var listaCargoDTO = _mapper.Map<List<CargoDTO>>(listaCargos);

            if (listaCargoDTO.Count > 0)
                return Ok(listaCargoDTO);
            else
                return NotFound();
        }
    }
}
