using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using WebApplication9.Services;
using Microsoft.Extensions.Configuration;
using WebApplication9.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using WebApplication9.ViewModels;
using WebApplication9.Models.ViewModels;

namespace WebApplication9
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("config.json").AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddEntityFrameworkSqlServer().AddDbContext<PortContext>();
            //var sqlConnectionString = Configuration["Data:PortContextConnection"];
            //services.AddEntityFramework().AddSqlServer().AddDbContext<PortContext>(options => options.UseSqlServer(sqlConnectionString));
            //services.AddDbContext<PortContext>(options => options.UseSqlServer(sqlConnectionString));
            //services.AddDbContext<PortContext>(options => options.UseSqlServer(sqlConnectionString));
            //services.AddDbContext<PortContext>();
            //services.AddMvc();
            //services.AddDbContext<PortContext>(options => options.UseSqlServer(sqlConnectionString));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddMvc().AddJsonOptions( opt => {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddLogging();
            //if (env.IsDevelopment())
            //{
            //    services.AddScoped<IMailService, IDebugMailService>();
            //}
            //else
            //{
            services.AddScoped<CoordService>();
            services.AddTransient<PortContextSeedData>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IPortRepository, PortRepository>();
            //}
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, PortContextSeedData seeder)
        {
            loggerFactory.AddDebug(LogLevel.Warning);
            //loggerFactory.AddConsole();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //app.UseRequestLocalization();
            Mapper.Initialize(config => {
                config.CreateMap<Trip, TripViewModel>().ReverseMap();
                config.CreateMap<Category, CategoryViewModel>().ReverseMap();
                config.CreateMap<Stop, StopViewModel>().ReverseMap();
                config.CreateMap<Post, PostViewModel>().ReverseMap();
                config.CreateMap<Author, AuthorViewModel>().ReverseMap();
            });
            app.UseStaticFiles();
            app.UseMvc( config => {
                config.MapRoute(
                     name: "default",
                     template: "{controller}/{action}/{id?}",
                     defaults: new { controller = "App", action = "Index" }
                    );
            });
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            seeder.EnsureSeedData();

        }
    }
}
