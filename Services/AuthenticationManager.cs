using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Services.Contracts;

namespace Services
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationManager(ILoggerService logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUser(UserDtoForRegistration userDtoForRegistration)
        {
            var user = _mapper.Map<User>(userDtoForRegistration);

            var result = await _userManager.CreateAsync(user,userDtoForRegistration.Password);
            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, userDtoForRegistration.Roles);
            return result;
        }
    }
}
