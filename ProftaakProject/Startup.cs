using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Context.SQLContext;
using ProftaakProject.Models;
using ProftaakProject.Models.Repositories;
using ProftaakProject.Repositories;

namespace ProftaakProject
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
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            services.AddTransient<IUserStore<Account>, MSSQLUserContext>();
            services.AddTransient<IRoleStore<Role>, MSSQLRoleContext>();
            services.AddIdentity<Account, Role>().AddDefaultTokenProviders();

            services.AddTransient<IPostContext, MSSQLPostContext>();
            services.AddTransient<ITagContext, MSSQLTagContext>();
            services.AddTransient<IAuthContext, MSSQLAuthContext>();
            services.AddTransient<IReactieContext, MSSQLReactieContext>();
            services.AddTransient<IAccountContext, MSSQLAccountContext>();
            services.AddTransient<IUitzendContext, MSSQLUitzendContext>();
            services.AddTransient<IEventContext, MSSQLEventContext>();
            services.AddTransient<IRoleContext, MSSQLRoleNonAuthContext>();

            services.AddScoped<PostRepo>();
            services.AddScoped<UitzendRepo>();
            services.AddScoped<AccountRepo>();
            services.AddScoped<ReactieRepo>();
            services.AddScoped<EvenementRepo>();
            services.AddScoped<RoleRepo>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
                endpoints.MapControllerRoute(
                    name: "evenement",
                    pattern: "{controller=Evenement}/{action=Index}");
                endpoints.MapControllerRoute(
                    name: "profiel",
                    pattern: "profiel/{id?}",
                    defaults: new {controller = "Account", action = "Profiel"}
                    );
            });
        }
    }
}
