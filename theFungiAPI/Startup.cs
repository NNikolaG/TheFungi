using AspNedelja3.Implementation.Emails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using theFungiAPI.Core;
using theFungiAPI.Extensions;
using theFungiApplication;
using theFungiApplication.Commands;
using theFungiApplication.Email;
using theFungiApplication.Loggers;
using theFungiApplication.Queries;
using theFungiApplication.UseCases;
using theFungiDataAccess;
using theFungiImplementation.Commands;
using theFungiImplementation.Loggers;
using theFungiImplementation.Queries;
using theFungiImplementation.Validators;

namespace theFungiAPI
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
            var settings = new AppSettings();

            Configuration.Bind(settings);

            services.AddSingleton(settings);

            services.AddSingleton(settings);
            services.AddApplicationUser();
            services.AddJwt(settings);
            //services.AddVezbeDbContext();
            services.AddUseCases();

            services.AddDbContext<theFungiDbContext>();

            services.AddTransient<IEmailSender>(x =>
            new SmtpEmailSender(settings.EmailOptions.FromEmail,
                    settings.EmailOptions.Password,
                    settings.EmailOptions.Port,
                    settings.EmailOptions.Host));

            services.AddHttpContextAccessor();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TheFungi.Api", Version = "v1" });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TheFungi.Api v1"));
            }

            app.UseRouting();

            app.UseMiddleware<UseGlobalExceptionHandler>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
