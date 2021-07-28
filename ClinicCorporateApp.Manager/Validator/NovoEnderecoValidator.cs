using ClinicCorporateApp.Core.Shared.ModelViews;
using FluentValidation;

namespace ClinicCorporateApp.Manager.Validator
{
    public class NovoEnderecoValidator : AbstractValidator<NovoEndereco>
    {
        public NovoEnderecoValidator()
        {
            RuleFor(p => p.Cidade).NotEmpty().NotNull().MaximumLength(200);
        }
    }
}
