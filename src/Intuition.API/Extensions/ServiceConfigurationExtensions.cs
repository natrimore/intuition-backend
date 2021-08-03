using Intuition.Domains;
using Intuition.Infrastructures;
using Intuition.Infrastructures.Repositories;
using Intuition.Services.Auth;
using Intuition.Services.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Intuition.API.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            // registering all controllers
            services.AddControllers(action =>
            {
                action.ReturnHttpNotAcceptable = true;
                // action.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            }).AddNewtonsoftJson(setupAction =>
            {
                setupAction.SerializerSettings.ContractResolver =
                   new CamelCasePropertyNamesContractResolver();

                setupAction.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

            }).AddXmlDataContractSerializerFormatters()
              // .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>())
              .ConfigureApiBehaviorOptions(options =>
              {
                  options.InvalidModelStateResponseFactory = context =>
                  {
                      var problemDetails = new ValidationProblemDetails(context.ModelState)
                      {
                          Type = "http://api.mobilpay.uz/",
                          Title = "One or more model validation errors occured.",
                          Status = StatusCodes.Status422UnprocessableEntity,
                          Detail = "See the errors property for details.",
                          Instance = context.HttpContext.Request.Path
                      };

                      problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                      return new UnprocessableEntityObjectResult(problemDetails)
                      {
                          ContentTypes = { "application/problem+json" }
                      };

                  };
              });

            return services;
        }

        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("MobilPayDbPostgreSql")));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityRepository, IdentityRepository>();

            return services;
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection(nameof(JwtIssuerOptions));

            var secretKey = jwtOptions[nameof(JwtIssuerOptions.SecretKey)];

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            // configuring JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidAudiences = new[] { "intuition" },
                ValidateAudience = true,
                // ValidAudience = jwtOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RoleClaimType = "role",
                NameClaimType = "name",

            };

            services.Configure<TokenValidationParameters>(cfg => cfg = tokenValidationParameters);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            return services;
        }

        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                  .RequireAuthenticatedUser()
                  .Build();

                options.AddPolicy("AdminUserPolicy", policy => policy.RequireRole(new string[] { "Admin" }));
                options.AddPolicy("CustomerPolicy", policy =>
                {
                    policy.RequireRole(new string[] { "Customer" });
                    policy.RequireClaim("PhoneNumberConfirmed", new string[] { "True" });
                });
                options.AddPolicy("UnverifiedCustomerPolicy", policy =>
                {
                    policy.RequireRole(new string[] { "Customer" });
                    policy.RequireClaim("PhoneNumberConfirmed", new string[] { "False" });
                });
            });

            return services;
        }

        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 4;
            }).AddEntityFrameworkStores<IdentityContext>()
              .AddDefaultTokenProviders()
              .AddUserStore<UserStore<AppUser, AppRole, IdentityContext, Guid>>()
              .AddRoleStore<RoleStore<AppRole, IdentityContext, Guid>>()
              .AddRoleManager<RoleManager<AppRole>>();

            return services;
        }

        public static IServiceCollection AddCustomApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(cfg =>
            {
                cfg.DefaultApiVersion = new ApiVersion(1, 0);
                cfg.AssumeDefaultVersionWhenUnspecified = true;
                cfg.ReportApiVersions = true;

                // cfg.ApiVersionReader = new HeaderApiVersionReader("ver", "X-iPay-Version");
                //var versionReader = new HeaderApiVersionReader("v"); // in query
                //versionReader.HeaderNames.Add("x-iPay-version"); // in header
                //cfg.ApiVersionReader = versionReader;

                // even we can set conventions for versioning
            });

            return services;
        }
    }
}
