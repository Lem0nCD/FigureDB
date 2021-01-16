using Autofac;
using AutoMapper;
using FigureDB.Common.Extensions;
using FigureDB.IdentityServer.Configure;
using FigureDB.IRepository;
using FigureDB.IService;
using FigureDB.Repository;
using FigureDB.Service;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace FigureDB.IdentityServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            });
            //.AddTestUsers(TestUsers.Users);
            builder.AddProfileService<FigureDBProfileService>();
            builder.AddResourceOwnerValidator<FigureDBResourceOwnerPasswordValidator>();

            // in-memory, code config
            builder.AddInMemoryIdentityResources(Config.IdentityResources);
            builder.AddInMemoryApiScopes(Config.ApiScopes);
            builder.AddInMemoryClients(Config.Clients);

            services.AddDBContext(Configuration);
            //services.AddScoped<IUserIdentityRepository, UserIdentityRepository>();
            //services.AddScoped<IUserIdentityService, UserIdentityService>();

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            services.AddAuthentication();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            Assembly assemblysRepository = Assembly.Load("FigureDB.Repository");
            Assembly assemblysService = Assembly.Load("FigureDB.Service");

            builder.RegisterAssemblyTypes(assemblysRepository)
                //.Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assemblysService)
                //.Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(options =>
            {
                options.WithOrigins(Configuration.GetSection("WithOrigins").Get<string[]>());
                options.AllowAnyHeader().AllowAnyMethod();
            });
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}