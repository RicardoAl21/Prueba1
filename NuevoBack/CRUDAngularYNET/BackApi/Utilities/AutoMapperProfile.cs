using AutoMapper;
using BackApi.DTO;
using BackApi.Models;
using System.Globalization;

namespace BackApi.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Cargo
            CreateMap<Cargo, CargoDTO>().ReverseMap();
            #endregion

            #region Departamento
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
            #endregion

            #region User
            CreateMap<User, UserDTO>()
                .ForMember(destino => destino.NombreDepartamento, opt => opt.MapFrom(origen => origen.IdDepartamentoNavigation.Nombre))
                .ForMember(destino => destino.NombreCargo, opt => opt.MapFrom(origen => origen.IdCargoNavigation.Nombre));

            CreateMap<UserDTO, User>()
                .ForMember(destino => destino.IdDepartamentoNavigation, opt => opt.Ignore())
                .ForMember(destino => destino.IdCargoNavigation, opt => opt.Ignore());
            #endregion
        }
    }
}
