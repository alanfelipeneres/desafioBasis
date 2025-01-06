using Biblioteca.Application.Interfaces;
using Biblioteca.Application.Mappings;
using Biblioteca.Application.Services;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;
using Biblioteca.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Ioc
{
    
    public static class DependencyInjection
    {
        /// <summary>
        /// Método de extensão: Permite utilizar o método como se ele fosse um método de um tipo já existente
        /// Neste caso o método AddInfrastructure vai "pertencer" a interface IServiceCollection
        /// Para funcionar perfeitamente o retorno de método deve ser do tipo que ele está extendendo
        /// E o primeiro parâmetro também deve ser do tipo que ele está extendendo e tem de ser precedido do termo 'this'
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BibliotecaContext>(
                option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IAssuntoRepository, AssuntoRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IViewLivrosPorAutorRepository, ViewLivrosPorAutorRepository>();

            //Services
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<IAssuntoService, AssuntoService>();
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IViewLivrosPorAutorService, ViewLivrosPorAutorService>();
            
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            return services;
        }
    }
}
