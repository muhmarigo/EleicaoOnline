using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EleicaoOnline.Data;
using EleicaoOnline.Models;
using EleicaoOnline.Validators;
using FluentValidation;

namespace EleicaoOnline.Services
{
    public class VotoService
    {
        private readonly VotoValidator validator;
        private readonly EleicaoContext context;

        public VotoService(VotoValidator validator, EleicaoContext context)
        {
            this.validator = validator;
            this.context = context;
        }

        public async Task<Voto> Votar(Voto model)
        {
            await validator.ValidateAndThrowAsync(model);

            await context.AddAsync(model);

            await context.SaveChangesAsync();

            return model;

        }
    }
}
