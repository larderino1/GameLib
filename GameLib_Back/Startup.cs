using DbManager.Data;
using GameLib_Back.Services.CategoryServices;
using GameLib_Back.Services.GameServices;
using GameLib_Back.Services.GenreServices;
using GameLib_Back.Services.ModeServices;
using GameLib_Back.Services.PlatformServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GameLib_Back
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AzureSqlDbConnectionString")));

            RegisterServices(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IGameServices, GameServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IModeServices, ModeServices>();
            services.AddScoped<IPlatformServices, PlatformServices>();
            services.AddScoped<IGenreServices, GenreServices>();
        }
    }
}
