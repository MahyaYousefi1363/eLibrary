using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Application.Books;
using eLibrary.Library.Application.Books.Contracts;
using eLibrary.Library.Application.Members;
using eLibrary.Library.Application.Members.Contracts;
using eLibrary.Library.Application.Rents;
using eLibrary.Library.Application.Rents.Contracts;
using eLibrary.Library.Domain.Books;
using eLibrary.Library.Domain.Members;
using eLibrary.Library.Domain.Rents;
using eLibrary.Library.Infrastructure.Persistence;
using eLibrary.Library.Infrastructure.Persistence.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace eLibrary
{
    public static class DependencyInjection
    {
        public static void AddeLibraryServices(this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment env)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddLibraryServices(configuration,env);
            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);
        }

        private static void AddLibraryServices(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment env
        )
        {
            services.AddScoped<IBookManager, BookManager>();
            services.AddScoped<IMemberManager, MemberManager>();
            services.AddScoped<IRentManager, RentManager>();
            
            services.AddScoped<IBookRepository, BookSqlRepository>();
            services.AddScoped<IMemberRepository, MemberSqlRepository>();
            services.AddScoped<IRentRepository, RentSqlRepository>();
            
            if (env.IsDevelopment())
            {
                services.AddDbContext<LibraryContext>(option =>
                {
                    option.UseSqlServer(configuration.GetConnectionString("Library"));
                });
            }
        }
    }
}