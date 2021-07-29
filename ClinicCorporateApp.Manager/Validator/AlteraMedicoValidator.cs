using ClinicCorporateApp.Core.Shared.ModelViews;
using ClinicCorporateApp.Manager.Interfaces.Repositories;
using FluentValidation;

namespace ClinicCorporateApp.Manager.Validator
{
    public class AlteraMedicoValidator : AbstractValidator<AlteraMedico>
    {
        public AlteraMedicoValidator(IEspecialidadeRepository repository)
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
            Include(new NovoMedicoValidator(repository));
        }
    }
}
