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
    public class CanditatoValidator : AbstractValidator<Candidato>
    {
        private readonly EleicaoContext context;

        public CanditatoValidator(EleicaoContext context)
        {
            this.context = context;
            RuleFor(x => x).MustAsync(TemQueSerUnico(context)).WithMessage("Um Canditato não pode concorrer mais de uma vez na mesma eleição");
        }

        private static Func<Candidato, CancellationToken, Task<bool>> TemQueSerUnico(EleicaoContext context)
        {
            return async (cadidato, token) =>
            {
                return !await context.Candidatos.AnyAsync(x => x.EleicaoId == cadidato.EleicaoId && x.PoliticoId == cadidato.PoliticoId);
            };
        }
    }
}
