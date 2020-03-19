using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using PluralSight.Models;
using PluralSight.Models.Features.Navigation;
using PluralSight.Services;

namespace PluralSight
{
    public class Startup
    {

        public IConfiguration conf { get; }
        public Startup(IConfiguration _conf)
        {
            conf = _conf;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(conf.GetConnectionString("DefaultConnection")));

            //Option Pattern
            services.Configure<NavigationConfiguration>(conf.GetSection("Features"));

            services.AddTransient<GuidService>();

            services.AddSingleton<SingletonService>();

            services.AddScoped<ScopeService>();

            //Add Identity Entityframework
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();

            //services.AddScoped<IPieRepository, MockPieRepository>();
            //services.AddScoped<ICategoryRepository, MockCategoryRepository>();
            services.AddScoped<IPieRepository, PieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddControllersWithViews();

            //Here, we are passing service provider to through GetCart which return Shopping Card Object
            services.AddScoped<ShoppingCart>( sp => ShoppingCart.GetCart(sp));
            services.AddHttpContextAccessor(); //give access to http context
            services.AddSession(); //give access to session

            //Required for scaffolded files
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseSession(); // Import the middleware to use session

            //Enable MVC Convention Routing
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllerRoute(
                    name: "default", pattern: "{controller=Home}/{action=Index}/{id:int?}");

                endpoints.MapRazorPages();
                    
            });
        }
    }
}
