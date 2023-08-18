﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookServices> _bookService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager,ILoggerService logger,IMapper mapper,IBookLinks bookLinks,UserManager<User> userManager,IConfiguration configuration)
        {
            _bookService = new Lazy<IBookServices>(() => new BookManager(repositoryManager,logger,mapper,bookLinks));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationManager(logger,mapper,userManager,configuration));
        }
        public IBookServices BookServices => _bookService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
