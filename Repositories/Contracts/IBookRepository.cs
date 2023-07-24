using Entities.RequestFeatures;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        void CreateOneBook(Book book);
        void DeleteOneBook(Book book);
        void UpdateOneBook(Book book);
        Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParams,bool trackChanges);
        Task<Book> GetOneBookByIdAsync(int id,bool trackChanges);
    }
}
