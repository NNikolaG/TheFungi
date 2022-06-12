using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using theFungiAPI.Core;
using theFungiApplication;
using theFungiApplication.Commands;
using theFungiApplication.Loggers;
using theFungiApplication.Queries;
using theFungiApplication.UseCases;
using theFungiApplication.UseCases.Commands;
using theFungiDataAccess;
using theFungiImplementation.Commands;
using theFungiImplementation.Loggers;
using theFungiImplementation.Queries;
using theFungiImplementation.Validators;

namespace theFungiAPI.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<theFungiDbContext>();
                var settings = x.GetService<AppSettings>();

                return new JwtManager(context, settings.JwtSettings);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
        public static void AddUseCases(this IServiceCollection services)
        {
            //Queries
            services.AddTransient<IGetCategoriesQuery, EFGetCollections>();
            services.AddTransient<IGetSingleCollectionQuery, EFGetSingleCollectionQuery>();
            services.AddTransient<IGetSingleCollectionItemQuery, EFGetSingleCollectionItemQuery>();

            //Commands
            services.AddTransient<ICreateCollectionCommand, EFCreateCollectionCommand>();
            services.AddTransient<ICreateCollectionItemCommand, EFCreateCollectionItemCommand>();
            services.AddTransient<ICreateCollectionItemInfoCommand, EFCreateCollectionItemInfoCommand>();
            services.AddTransient<ICreateFollowCommand, EFCreateFollowCommand>();
            services.AddTransient<IRegisterUserCommand, EFRegisterUserCommand>();

            //Validators
            services.AddTransient<CreateCollectionValidator>();
            services.AddTransient<CreateCollectionItemValidator>();
            services.AddTransient<CreateCollectionItemInfoValidator>();
            services.AddTransient<CreateFollowValidator>();
            services.AddTransient<RegisterUserValidator>();

            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();

        }

        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                //Pristup payload-u
                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonimousUser();
                }

                var actor = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Email").Value,
                    // "[1, 2, 3, 4, 5]"
                    AllowedUseCases = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("AllowedUseCases").Value)
                };

                return actor;
            });
        }

        public static void AddVezbeDbContext(this IServiceCollection services)
        {
            services.AddTransient(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var conString = x.GetService<AppSettings>().ConnString;

                optionsBuilder.UseSqlServer(conString);

                var options = optionsBuilder.Options;

                return new theFungiDbContext(options);
            });
        }

    }
}
