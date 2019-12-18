using AutoMapper;
using DeepBlue.CrossCutting.IoC;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO.Compression;

namespace DeepBlue.Presentation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(
                    options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = false;
                
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opcoes =>
                {
                    opcoes.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            RegisterServices(services, Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Sistema de Gerenciamento de Pessoas",
                        Version = "v1",
                        Description = "Projeto desenvolvido com .NET CORE, EntityFramework e MediatR",
                        Contact = new Contact
                        {
                            Name = "Luiz Guilherme Bandeira",
                            Url = "https://www.cotiinformatica.com.br/"
                        }
                    });
            });

            services.AddCors(c => c.AddPolicy("DefaultPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            }));


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "DeepBlue");

            });

            app.UseCors("DefaultPolicy");
        }

        private static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            NativeInjectorBootStrapper.Register(services, configuration);
        }
    }
}
