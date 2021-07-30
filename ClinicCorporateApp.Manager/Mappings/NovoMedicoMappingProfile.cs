using AutoMapper;
using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Core.Shared.ModelViews;

namespace ClinicCorporateApp.Manager.Mappings
{
    public class NovoMedicoMappingProfile : Profile
    {
        public NovoMedicoMappingProfile()
        {
            CreateMap<NovoMedico, Medico>();
            CreateMap<Medico, MedicoView>();
            CreateMap<Especialidade, ReferenciaEspecialidade>().ReverseMap();
            CreateMap<Especialidade, EspecialidadeView>().ReverseMap();
            CreateMap<Especialidade, NovaEspecialidade>().ReverseMap();
            CreateMap<AlteraMedico, Medico>().ReverseMap();
        }
    }
}
