using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Execution;
using eLibrary.Library.Domain.Books;
using eLibrary.Library.Domain.Rents;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Library.Infrastructure.Persistence
{
    public class LibraryContext: DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options):base(options)
        {
            
        }   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
        public DbSet<Book> books => Set<Book>();
        public DbSet<eLibrary.Library.Domain.Members.Member> members=>Set<eLibrary.Library.Domain.Members.Member>();
        public DbSet<Rent> rents => Set<Rent>();
    }
}