using ClinicCorporateApp.Core.Shared.ModelViews;
using ClinicCorporateApp.Manager.Interfaces.Repositories;
using FluentValidation;

namespace ClinicCorporateApp.Manager.Validator
{
    public class NovoMedicoValidator : AbstractValidator<NovoMedico>
    {
        public NovoMedicoValidator(IEspecialidadeRepository repository)
        {
            RuleFor(p => p.Nome).NotNull().MaximumLength(200);

            RuleFor(p => p.CRM).NotNull().GreaterThan(0);

            RuleForEach(p => p.Especialidades).SetValidator(new ReferenciaEspecialidadeValidator(repository));
        }
    }
}
