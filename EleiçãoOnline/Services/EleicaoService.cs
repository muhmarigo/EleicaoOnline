using EleicaoOnline.Data;
using EleicaoOnline.Models;
using EleicaoOnline.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using EleicaoOnline.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EleicaoOnline.Services
{
    public class EleicaoService
    {
        private readonly EleicaoValidator validator;
        private readonly EleicaoContext context;

        public EleicaoService(EleicaoValidator validator, EleicaoContext context)
        {
            this.validator = validator;
            this.context = context;
        }

        public async Task<Eleicao> CadastrarEleicao(Eleicao model)
        {
            await validator.ValidateAndThrowAsync(model);

            await context.AddAsync(model);

            await context.SaveChangesAsync();

            return model;
        }

        public ListaDePoliticosEleicao RetornaPoliticos(int id, int page, string search)
        {
            var lista = context.Candidatos.Include(x => x.Politico).Include("Partido").Where(x => x.EleicaoId == id);
            var contagem = lista.Count();
            if (!string.IsNullOrWhiteSpace(search))
            {
                lista = lista.Where(x => x.Politico.Nome.Contains(search) || x.Politico.Partido.Nome.Contains(search));
            }
            return new ListaDePoliticosEleicao
            {
                Total = contagem,
                Politicos = lista.Skip((page - 1) * 10).Select(x => new ViewModels.Politico
                {
                    Id = x.Politico.Id,
                    Nome = x.Politico.Nome,
                    NomePartido = x.Politico.Partido.Nome,
                    NumeroPartido = x.Politico.Partido.Numero,
                }).ToList()
            };
        }
    }
}
