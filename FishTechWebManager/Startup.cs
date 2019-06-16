using FishTechWebManager._infra;
using FishTechWebManager._Repository;
using FishTechWebManager._Repository.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FishTechWebManager
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
