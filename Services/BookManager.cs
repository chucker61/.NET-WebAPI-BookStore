﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.RequestFeatures;
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
        private readonly IMapper _mapper;

        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<BookDto> CreateOneBookAsync(BookDtoForInsertion bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _manager.Book.CreateOneBook(book);
            await _manager.SaveAsync();
            return _mapper.Map<BookDto>(book);
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExist(id,trackChanges);
            _manager.Book.DeleteOneBook(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<BookDto> books,MetaData metaData)> GetAllBooksAsync(BookParameters bookParams,bool trackChanges)
        {
            if (!bookParams.ValidPriceRange)
                throw new PriceOutOfRangeBadRequestException();

            var booksWithMetaData = await _manager.Book.GetAllBooksAsync(bookParams,trackChanges);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);
            return (booksDto, booksWithMetaData.MetaData);
        }

        public async Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookByIdAndCheckExist(id, trackChanges);
            return _mapper.Map<BookDto>(book);
        }

        public async Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExist(id, trackChanges);
            entity = _mapper.Map<Book>(bookDto);
            _manager.Book.Update(entity);
            await _manager.SaveAsync();
        }
        private async Task<Book> GetOneBookByIdAndCheckExist(int id, bool trackChanges)
        {
            var entity = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);
            if (entity is null)
                throw new BookNotFoundException(id);
            return entity;
        }
    }
}
