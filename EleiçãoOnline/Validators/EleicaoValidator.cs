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
    public class EleicaoValidator : AbstractValidator<Eleicao>
    {
        private readonly EleicaoContext context;

        public EleicaoValidator(EleicaoContext context)
        {
            this.context = context;

            RuleFor(x => x.Ano).NotEmpty().LessThanOrEqualTo(DateTime.Today.Year);
            RuleFor(x => x).MustAsync(NaoTerTidoElecaoDoMesmoCardoNosUltimos2Anos(context)).WithMessage("É preciso esperar pelo menos 2 anos para fazer uma eleição com cargo repetido");
        }

        private static Func<Eleicao, CancellationToken, Task<bool>> NaoTerTidoElecaoDoMesmoCardoNosUltimos2Anos(EleicaoContext context)
        {
            return async (eleicao, token) =>
            {
                var anoLimiteAntes = eleicao.Ano - 2;
                var anoLimiteDepois = eleicao.Ano + 2;
                return !await context.Eleicoes.AnyAsync(x => x.Cargo == eleicao.Cargo && (x.Ano > anoLimiteAntes && x.Ano < anoLimiteDepois));
            };
        }
    }
}
