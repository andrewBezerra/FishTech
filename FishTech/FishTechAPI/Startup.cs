using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FishTechWebManager._infra;
using FishTechWebManager._Repository;
using FishTechWebManager._Repository.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace FishTechAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "FishTech.API",
                        Version = "v1",
                        
                    });

               
            });
            services.AddSingleton<IDB, MSSQL>();

            services.AddTransient<IAtividadeRepository, AtividadeRepository>();
            services.AddTransient<IDispositivoRepository, DispositivoRepository>();
            services.AddTransient<IEspecieRepository, EspecieRepository>();
            services.AddTransient<IIndicadorRepository, IndicadorRepository>();
            services.AddTransient<IInformacoesRepository, InformacoesRepository>();
            services.AddTransient<IMedicaoRepository, MedicaoRepository>();
            services.AddTransient<IProdutorRepository, ProdutorRepository>();
            services.AddTransient<ITanqueRepository, TanqueRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "FishTech");
            });
            app.UseMvc();
            
        }
    }
}
