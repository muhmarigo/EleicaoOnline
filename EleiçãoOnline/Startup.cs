using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using EleicaoOnline.Services;
using EleicaoOnline.Data;
using EleicaoOnline.Validators;

namespace EleicaoOnline
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EleicaoContext>(x => x.UseInMemoryDatabase(Guid.NewGuid().ToString()), ServiceLifetime.Singleton);
            services.AddEntityFrameworkInMemoryDatabase();
            services.AddScoped<PartidoService>();
            services.AddScoped<PartidoValidator>();
            services.AddScoped<PoliticoService>();
            services.AddScoped<PoliticoValidator>();
            services.AddScoped<EleicaoService>();
            services.AddScoped<EleicaoValidator>();
            services.AddScoped<CandidatoService>();
            services.AddScoped<CanditatoValidator>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
