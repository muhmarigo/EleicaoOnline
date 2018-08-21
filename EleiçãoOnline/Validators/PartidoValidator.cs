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
    public class PartidoValidator : AbstractValidator<Partido>
    {
        private readonly EleicaoContext context;

        public PartidoValidator(EleicaoContext context)
        {
            this.context = context;

            RuleFor(x => x.Numero).NotEmpty().MustAsync(TerNumeroUnico).WithMessage("Numero deve ser unico");
            RuleFor(x => x.Nome).NotEmpty().MustAsync(TerNomeUnico).WithMessage("Nome deve ser unico");
        }

        public async Task<bool> TerNumeroUnico(byte numero, CancellationToken cancellationToken)
        {
            return !await context.Partidos.AnyAsync(x => x.Numero == numero);
        }

        public async Task<bool> TerNomeUnico(string nome, CancellationToken cancellationToken)
        {
            return !await context.Partidos.AnyAsync(x => x.Nome == nome);
        }
    }
}
