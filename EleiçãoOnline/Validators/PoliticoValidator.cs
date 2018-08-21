using EleicaoOnline.Data;
using EleicaoOnline.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EleicaoOnline.Validators
{
    public class PoliticoValidator : AbstractValidator<Politico>
    {
        private readonly EleicaoContext context;

        public PoliticoValidator(EleicaoContext context)
        {
            this.context = context;

            RuleFor(x => x.CPF).NotEmpty().MustAsync(TerCPFunico).WithMessage("CPF deve ser unico");
            RuleFor(x => x.RG).NotEmpty().MustAsync(TerRGUnico).WithMessage("RG deve ser unico");
            RuleFor(x => x.DataDeNascimento).Must(TerMaisDe18).WithMessage("O politico deve ser maior de 18 anos");
        }

        public async Task<bool> TerCPFunico(string cpf, CancellationToken cancellationToken)
        {
            return !await context.Politicos.AnyAsync(x => x.CPF == cpf);
        }

        public async Task<bool> TerRGUnico(string cpf, CancellationToken cancellationToken)
        {
            return !await context.Politicos.AnyAsync(x => x.RG == cpf);
        }

        public bool TerMaisDe18(DateTime nascimento)
        {
            var dif = (new DateTime(1, 1, 1) + (DateTime.Today - nascimento)).Year;
            return dif >= 18;
        }

    }
}
