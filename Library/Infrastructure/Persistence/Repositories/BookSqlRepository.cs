using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Library.Infrastructure.Persistence.Repositories
{
    public class BookSqlRepository : SqlRepository<Book, Guid>, IBookRepository
    {
        public BookSqlRepository(LibraryContext context)
            : base(context) { }

        public async override Task CreateEntityAsync(Book entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
