using GameLib_Front.Constants;
using GameLib_Front.Data;
using GameLib_Front.Services.CategoryServices;
using GameLib_Front.Services.GameServices;
using GameLib_Front.Services.GenreServices;
using GameLib_Front.Services.ModeServices;
using GameLib_Front.Services.PlatformServices;
using GameLib_Front.Services.RoleService;
using GameLib_Front.Services.StorageServices;
using GameLib_Front.Services.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Front
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
            services.AddDbContext<UserDataDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString(ConfigurationConstants.UserDataDbConnectionString)));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<UserDataDbContext>();

            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(
                    Configuration.GetConnectionString(ConfigurationConstants.StorageAccountConnectionString));
            });

            services.AddHttpClient();

            RegisterServices(services);

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IGameServices, GameServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IModeServices, ModeServices>();
            services.AddScoped<IPlatformServices, PlatformServices>();
            services.AddScoped<IGenreServices, GenreServices>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IStorageService, StorageService>();
        }
    }
}
