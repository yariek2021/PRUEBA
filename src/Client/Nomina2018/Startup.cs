
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nomina2018.Config;
using PersistenceLayer;
using ServiceLayer;
using System.Collections.Generic;
using System.Globalization;

namespace Nomina2018
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login/";
                options.LogoutPath = "/Account/Logout/";
                options.AccessDeniedPath = "/Account/AccessDenied/";
            });
            services.AddTransient<IEmpleadoService, EmpleadoService>();
            services.AddTransient<IDepartamentoService, DepartamentoService>();
            services.AddTransient<IPuestoService, PuestoService>();
            //services.AddTransient<ICatalogoService, CatalogoService>();
            //services.AddTransient<IObjetivoNominaService, ObjetivoNominaService>();
            //services.AddTransient<IConfiguracionNominaService,ConfiguracionNominaService>();
            //services.AddTransient<INominaService, NominaService>();
            services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IGuestConciergeService, GuestConciergeService>();
            //services.AddTransient<IReporteService, ReporteService>();
            //services.AddScoped<IViewRenderService, ViewRenderService>();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("es-ES");
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            AutoMapperConfig.Initialize();

            loggerFactory.AddFile(env.ContentRootPath + "/Logs/log-{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //   app.UseRequestLocalization();

            var defaultDateCulture = "es-ES";
            var ci = new CultureInfo(defaultDateCulture);
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            // Configure the Localization middleware
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ci),
                SupportedCultures = new List<CultureInfo>
                {
                    ci,
                },
                SupportedUICultures = new List<CultureInfo>
                {
                    ci,
                }
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Empleado}/{action=Index}/{id?}");
            });

            Rotativa.AspNetCore.RotativaConfiguration.Setup(env, "..\\Rotativa\\Windows\\");
        }
    }


}
