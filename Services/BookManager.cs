﻿using Entities.Exceptions;
using Entity.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookServices
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;

        public BookManager(IRepositoryManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
        }
        public void CreateOneBook(Book book)
        {
            _manager.Book.CreateOneBook(book);
            _manager.Save();
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity == null)
                throw new BookNotFoundException(id);

            _manager.Book.DeleteOneBook(entity);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _manager.Book.GetAllBooks(trackChanges);
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            var book = _manager.Book.GetOneBookById(id, trackChanges);
            if (book == null)
                throw new BookNotFoundException(id);
            return book;
        }

        public void UpdateOneBook(int id, Book book, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);

            if (entity == null)
                throw new BookNotFoundException(id);

            entity.Name = book.Name;
            entity.Price = book.Price;

            _manager.Book.UpdateOneBook(entity);
            _manager.Save();
        }
    }
}
