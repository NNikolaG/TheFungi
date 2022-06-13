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
using theFungiApplication.UseCases.Queries;
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
            services.AddTransient<IGetCollectionsQuery, EFGetCollections>();
            services.AddTransient<IGetSingleCollectionQuery, EFGetSingleCollectionQuery>();
            services.AddTransient<IGetSingleCollectionItemQuery, EFGetSingleCollectionItemQuery>();
            services.AddTransient<IGetCategoriesQuery, EFGetCategories>();
            services.AddTransient<IGetSingleCategoryQuery, EFGetSingleCategoryQuery>();
            services.AddTransient<IGetFollowersQuery, EFGetFollowersQuery>();
            services.AddTransient<IGetLogsQuery, EFGetLogsQuery>();
            services.AddTransient<IGetCollectionItemsQuery, EFGetCollectionItemsQuery>();
            services.AddTransient<IGetCollectionItemInfosQuery, EFGetCollectionItemInfosQuery>();

            //Commands
            services.AddTransient<ICreateCollectionCommand, EFCreateCollectionCommand>();
            services.AddTransient<ICreateCollectionItemCommand, EFCreateCollectionItemCommand>();
            services.AddTransient<ICreateCollectionItemInfoCommand, EFCreateCollectionItemInfoCommand>();
            services.AddTransient<ICreateFollowCommand, EFCreateFollowCommand>();
            services.AddTransient<IRegisterUserCommand, EFRegisterUserCommand>();
            services.AddTransient<IChangeUserRoleCommand, EFChangeUserRoleCommand>();
            services.AddTransient<ICreateCategoryCommand, EFCreateCategoryCommand>();
            services.AddTransient<IUpdateCategoriesCommand, EFUpdateCategoriesCommand>();
            services.AddTransient<IDeleteCategoryCommand, EFDeleteCategoryCommand>();
            services.AddTransient<IUpdateCollectionsCommand, EFUpdateCollectionsCommand>();
            services.AddTransient<IDeleteCollectionCommand, EFDeleteCollectionCommand>();
            services.AddTransient<IDeleteFollowCommand, EFDeleteFollowCommand>();
            services.AddTransient<IUpdateCollectionItemCommand, EFUpdateCollectionItemCommand>();
            services.AddTransient<IDeleteCollectionItemCommand, EFDeleteCollectionItemCommand>();
            services.AddTransient<IUpdateCollectionItemInfoCommand, EFUpdateCollectionItemInfoCommand>();
            services.AddTransient<IDeleteCollectionItemInfoCommand, EFDeleteCollectionItemInfoCommand>();

            //Validators
            services.AddTransient<CreateCollectionValidator>();
            services.AddTransient<CreateCollectionItemValidator>();
            services.AddTransient<CreateCollectionItemInfoValidator>();
            services.AddTransient<CreateFollowValidator>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<ChangeUserRoleValidator>();
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<UpdateCollectionValidator>();
            services.AddTransient<UpdateCollectionItemValidator>();
            services.AddTransient<UpdateCollectionItemInfoValidator>();

            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<IUseCaseLogger, Logger>();

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

        //public static void AddVezbeDbContext(this IServiceCollection services)
        //{
        //    services.AddTransient(x =>
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder();

        //        var conString = x.GetService<AppSettings>().ConnString;

        //        optionsBuilder.UseSqlServer(conString);

        //        var options = optionsBuilder.Options;

        //        return new theFungiDbContext(options);
        //    });
        //}

    }
}
