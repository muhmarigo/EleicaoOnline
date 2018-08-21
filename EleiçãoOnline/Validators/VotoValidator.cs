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
    public class VotoValidator : AbstractValidator<Voto>
    {
        private readonly EleicaoContext context;

        public VotoValidator(EleicaoContext context)
        {
            this.context = context;

            When(x => x.Tipo == Enums.TipoVoto.Candidato, () =>
            {
                RuleFor(x => x.PoliticoId).NotNull();
            });

            RuleFor(x => x).MustAsync(VotoUnicoPorEleicao(context));
        }

        private static Func<Voto, CancellationToken, Task<bool>> VotoUnicoPorEleicao(EleicaoContext context)
        {
            return async (voto, token) =>
            {
                return !await context.Votos.AnyAsync(x => x.EleicaoId == voto.EleicaoId && x.CPFEleitor == voto.CPFEleitor);
            };
        }
    }
}
