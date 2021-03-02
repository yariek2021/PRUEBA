using AutoMapper;
using DomainLayer;
using DtoLayer;

namespace Nomina2018.Config
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Usuario, UserGetDto>().ReverseMap();
                cfg.CreateMap<Role, RoleCreateDto>().ReverseMap();

                cfg.CreateMap<UsuarioRole, UsuarioRoleUpdate>().ReverseMap();
                cfg.CreateMap<EmpleadoBaseDto, Empleado>().ReverseMap();
            });
        }
    }
}
