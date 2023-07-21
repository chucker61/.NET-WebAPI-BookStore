﻿using Entities.DataTransferObjects;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookServices
    {
        IEnumerable<BookDto> GetAllBooks(bool trackChanges);
        Book GetOneBookById(int id, bool trackChanges);
        void CreateOneBook(Book book);
        void UpdateOneBook(int id, BookDtoForUpdate bookDto, bool trackChanges);
        void DeleteOneBook(int id, bool trackChanges);
    }
}
