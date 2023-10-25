using AutoMapper;
using BackApi.DTO;
using BackApi.Models;
using BackApi.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackApi.Controllers
{
    [Route("usuarios")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public UserController(IUserService userService, IMapper mapper)
        {
          _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<UserDTO>>> GetList()
        {
            var listUser = await _userService.GetUsers();
            var listUserDTO = _mapper.Map<List<UserDTO>>(listUser);
            
            if(listUserDTO.Count > 0)
                return Ok(listUserDTO);
            else
                return NotFound();
        }


        [HttpGet]
        [Route("FilterbyCargo/{cargo}")]

        public async Task<ActionResult<List<UserDTO>>> GetListByCargo(int cargo)
        {
            var listUcargo = await _userService.GetUsersByCargo(cargo);
            var listUcargoDTO = _mapper.Map<List<UserDTO>>(listUcargo);

            if (listUcargoDTO.Count > 0)
                return Ok(listUcargoDTO);
            else
                return NotFound();
        }



        [HttpGet]
        [Route("FilterbyDepartamento/{departamento}")]

        public async Task<ActionResult<List<UserDTO>>> GetListByDepartamento(int departamento)
        {
            var listUdepa = await _userService.GetUsersByDepartamento(departamento);
            var listUdepaDTO = _mapper.Map<List<UserDTO>>(listUdepa);

            if (listUdepaDTO.Count > 0)
                return Ok(listUdepaDTO);
            else
                return NotFound();
        }



        [HttpPost]
        [Route("guardar")]
        
        public async Task<ActionResult<User>> Add(UserDTO modelo)
        {
            var _user = _mapper.Map<User>(modelo);
            var _userCreado = await _userService.Add(_user);

            if (_userCreado.IdUser != 0)
                return Ok(_mapper.Map<UserDTO>(_userCreado));
            else
                return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        [Route("actualizar/{IdUser}")]
        public async Task<ActionResult<bool>> Update(int IdUser,UserDTO modelo)
        {
            var _found = await _userService.GetUser(IdUser);

            if (_found is null) return NotFound();

            var _usuario = _mapper.Map<User>(modelo);

            _found.Usuario = _usuario.Usuario;
            _found.Primernombre = _usuario.Primernombre; 
            _found.Segundonombre = _usuario.Segundonombre;
            _found.Primerapellido = _usuario.Primerapellido;
            _found.Segundoapellido = _usuario.Segundoapellido;
            _found.IdDepartamento = _usuario.IdDepartamento;
            _found.IdCargo = _usuario.IdCargo;

            var resp = await _userService.Update(_found);

            if (resp)
                return Ok(_mapper.Map<UserDTO>(_found));
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        [Route("eliminar/{IdUser}")]

        public async Task<ActionResult<bool>> Delete(int IdUser)
        {
            var _found = await _userService.GetUser(IdUser);

            if (_found is null) return NotFound();

            var respuesta = await _userService.Delete(_found);

            if (respuesta)
                return Ok();
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
