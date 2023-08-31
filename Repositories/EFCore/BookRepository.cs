using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
        public void CreateOneBook(Book book) => Create(book);
        public void DeleteOneBook(Book book) => Delete(book);
        public async Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParams,bool trackChanges)
        {
            var books = await FindAll(trackChanges)
                .FilterBooks(bookParams.MinPrice, bookParams.MaxPrice)
                .Search(bookParams.SearchTerm)
                .Sort(bookParams.OrderBy).ToListAsync();
            return PagedList<Book>.ToPagedList(books, bookParams.PageSize,bookParams.PageNumber);
        }
        public Task<List<Book>> GetAllBooksAsync(bool trackChanges)
        {
            var books = FindAll(trackChanges).ToListAsync();
            return books;
        }
        public async Task<Book> GetOneBookByIdAsync(int id, bool trackChanges) => 
            await FindByCondition(b => b.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        public void UpdateOneBook(Book book) => Update(book);
    }
}
