using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Context;
using Theraphosidae.Infrastructure.Settings;
using Theraphosidae.Services;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae
{
    public class Startup
    {

        //Wstrzykniecie pliku konfiguracyjnego
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile("secrets.json");
            Configuration = config.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TheraphosidaeContext>(builder =>
            {
                builder.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<TheraphosidaeContext>();

            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
            {
                // scie¿ka do logowania
                options.LoginPath = "/dashboard/account/login";
            });

            //services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
            //{
            //    options.LoginPath = "/dashboard/account/login";
            //});

            services.AddRazorPages();
            services.AddControllersWithViews();

            services.AddOptions();

            // Tu wstrzykiwanie zaleznosci
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ITaxonomyService, TaxonomyService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<ISpiderService, SpiderService>();
            services.AddScoped<IAnimalTaxonomyService, AnimalTaxonomyService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IReportService, ReportService>();
            

            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            //services.Configure<Clo>
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var cultureInfo = new CultureInfo("pl-PL");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsProduction())
            {
                app.UseExceptionHandler("/blad");
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                           name: "default",
                           areaName: "home",
                           pattern: "{controller=Home}/{action=index}/{id?}");

                endpoints.MapAreaControllerRoute(
                           name: "dashboardArea",
                           areaName: "dashboard",
                           pattern: "{area=dashboard}/{controller=Home}/{action=index}/{id?}");

            });
        }
    }
}
