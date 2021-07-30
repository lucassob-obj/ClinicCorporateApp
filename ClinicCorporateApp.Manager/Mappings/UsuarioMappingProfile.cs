using AutoMapper;
using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Core.Shared.ModelViews.Usuario;

namespace ClinicCorporateApp.Manager.Mappings
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<Usuario, UsuarioView>().ReverseMap();
        }
    }
}
