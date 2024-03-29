﻿using AutoMapper;
using DeepBlue.Application.Contracts;
using DeepBlue.Application.Services;
using DeepBlue.Domain.Contracts.Logs;
using DeepBlue.Domain.Contracts.Repositories;
using DeepBlue.Domain.Contracts.Services;
using DeepBlue.Domain.Services;
using DeepBlue.Infraestructure.Data.Context;
using DeepBlue.Infraestructure.Data.Repositories;
using DeepBlue.Infraestructure.Logs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DeepBlue.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IPessoaApplicationService, PessoaApplicationService>();
            services.AddTransient<IPessoaDomainService, PessoaDomainService>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();

            services.AddTransient<IPessoaLog, PessoaLog>();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DeepBlue")));

        }
    }
}
