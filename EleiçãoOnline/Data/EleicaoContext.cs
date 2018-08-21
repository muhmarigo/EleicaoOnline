using EleicaoOnline.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EleicaoOnline.Data
{
    public class EleicaoContext : DbContext
    {

        public EleicaoContext(DbContextOptions<EleicaoContext> options)
            : base(options)
        {
        }

        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Politico> Politicos { get; set; }
        public DbSet<Eleicao> Eleicoes { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Voto> Votos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Partido>(b =>
            {
                b.Property(x => x.Nome).IsRequired();
                b.Property(x => x.Numero).IsRequired();

                b.HasIndex(x => x.Nome).IsUnique();
                b.HasIndex(x => x.Numero).IsUnique();
            });

            modelBuilder.Entity<Politico>(b =>
            {

                b.HasIndex(x => x.CPF).IsUnique();
                b.HasIndex(x => x.RG).IsUnique();

                b.Property(x => x.Nome).IsRequired();
                b.Property(x => x.CPF).IsRequired();
                b.Property(x => x.RG).IsRequired();
                b.Property(x => x.DataDeNascimento).IsRequired();

                b.HasOne(x => x.Partido).WithMany();
            });

            modelBuilder.Entity<Eleicao>(b =>
            {
                b.Property(x => x.Ano).IsRequired();
                b.Property(x => x.Pais).IsRequired();
                b.Property(x => x.Cargo).IsRequired();
                b.HasMany(x => x.Candidatos).WithOne();
                b.HasMany(x => x.Votos).WithOne();
            });

            modelBuilder.Entity<Candidato>(b =>
            {
                b.HasKey(x => new { x.EleicaoId, x.PoliticoId });
            });
        }
    }
}
