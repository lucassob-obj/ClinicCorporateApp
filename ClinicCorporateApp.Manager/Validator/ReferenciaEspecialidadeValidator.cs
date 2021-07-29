using ClinicCorporateApp.Core.Shared.ModelViews;
using ClinicCorporateApp.Manager.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace ClinicCorporateApp.Manager.Validator
{
    public class ReferenciaEspecialidadeValidator : AbstractValidator<ReferenciaEspecialidade>
    {
        private readonly IEspecialidadeRepository repository;
        public ReferenciaEspecialidadeValidator(IEspecialidadeRepository repository)
        {
            this.repository = repository;
            RuleFor(p => p.Id).NotEmpty().NotNull().GreaterThan(0).MustAsync(async (id, cancelar) =>
            {
                return await ExisteNaBase(id);
            }).WithMessage("Especialidade não cadastrada.");
        }

        

        private async Task<bool> ExisteNaBase(int id)
        {
            return await repository.ExisteAsync(id);
        }
    }
}
