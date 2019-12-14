using DeepBlue.Application.Contracts;
using DeepBlue.Application.Services;
using DeepBlue.Domain.Contracts.Logs;
using DeepBlue.Domain.Contracts.Repositories;
using DeepBlue.Domain.Contracts.Services;
using DeepBlue.Domain.Services;
using DeepBlue.Infraestructure.Data.Context;
using DeepBlue.Infraestructure.Data.Repositories;
using DeepBlue.Infraestructure.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeepBlue.Presentation.API
{
    public class DependencyResolver
    {
      
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IPessoaApplicationService, PessoaApplicationService>();
            services.AddTransient<IPessoaDomainService, PessoaDomainService>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();

            services.AddTransient<IPessoaLog, PessoaLog>();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DeepBlue")));

        }
    }
}
