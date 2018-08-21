using EleicaoOnline.Data;
using EleicaoOnline.Models;
using EleicaoOnline.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EleicaoOnline.Services
{
    public class PartidoService
    {
        private readonly EleicaoContext context;
        private readonly PartidoValidator validator;

        public PartidoService(
            EleicaoContext context,
            PartidoValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public async Task<Partido> CadastrarPartido(Partido model)
        {
            await validator.ValidateAndThrowAsync(model);

            await context.AddAsync(model);

            await context.SaveChangesAsync();

            return model;
        }
    }
}
