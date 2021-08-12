using AutoMapper;
using Intuition.API.Extensions;
using Intuition.API.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;

namespace Intuition.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services
                .AddCustomMvc()

                .AddDbContexts(Configuration)

                .AddCustomAuthentication(Configuration)
                
                .AddSingleton(Configuration)
                
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                
                .AddCustomAuthorization()

                .AddServices()

                .AddCustomIdentity();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Intuition.API", Version = "v1" });
            });

            services.AddAuthentication();
                //.AddGoogle("google", opt =>
                //{
                //    var googleAuth = Configuration.GetSection("Authentication:Google");
                //    opt.ClientId = googleAuth["ClientId"];
                //    opt.ClientSecret = googleAuth["ClientSecret"];
                //    opt.SignInScheme = IdentityConstants.ExternalScheme;
                //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IdentityAppInitializer identityAppInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Intuition.API v1"));
            }

            app.UseSerilogRequestLogging();

            app.UseCors(config =>
            {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });

            app.UseExceptionHandler(hanlder =>
            {
                hanlder.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("Ooops! An unexpected fault happened. Try again later.");
                });
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            identityAppInitializer
                .SeedAsync()
                .Wait();
        }
    }
}
