﻿using ClinicCorporateApp.Core.Shared.ModelViews;
using FluentValidation;
using System;

namespace ClinicCorporateApp.Manager.Validator
{
    public class NovoClienteValidator : AbstractValidator<NovoCliente>
    {
        public NovoClienteValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
            RuleFor(x => x.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-200));
            RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
            RuleFor(x => x.Telefone).NotNull().NotEmpty().Matches("[2-9][0-9]{9}").WithMessage("O telefone está em formato inválido.");
            RuleFor(x => x.Sexo).NotNull().NotEmpty().Must(IsMorF).WithMessage("Sexo precisa ser M ou F");
        }

        private bool IsMorF(char sexo)
        {
            return sexo == 'M' || sexo == 'F';
        }
    }
}
