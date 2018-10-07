using AutoMapper;
using Vuighe.Api.Configurations.Systems;
using Vuighe.Api.Extensions;
using Vuighe.Common.Constants;
using Vuighe.Model;
using Vuighe.Service.Implementations;
using Vuighe.Service.Interfaces;
using Vuighe.Service.Mapper;
using Vuighe.Api.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Vuighe.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env, IHostingEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        private readonly IHostingEnvironment _environment;
        private readonly string _assemblyName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString(ConfigurationKeys.DefaultConnection), x => x.MigrationsAssembly(_assemblyName)));

            services.ConfigureIdentityService(Configuration, _environment);
            ConfigIoc(services);
            services.AddImageResizer();
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
            }
            app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseImageResizer();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
        }

        public void ConfigIoc(IServiceCollection services)
        {
            services.AddScoped<AppInitializer>();
            services.AddScoped<ILoginHistoryService, LoginHistoryService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICollectionService, CollectionService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IEpisodeService, EpisodeService>();
            services.AddScoped<ICategoryFilmService, CategoryFilmService>();
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<ITagService, TagService>();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<Mapping>();
                cfg.IgnoreUnmapped();
            });
            services.AddSingleton(Mapper.Instance.RegisterMap());
        }
    }
}