using AutoMapper;
using ECommerce.Contracts;
using ECommerce.Contracts.Authors;
using ECommerce.EntityFramework;
using ECommerce.Services.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace ECommerce.Services
{
    public class UserService : BaseService, IAuthorsService
    {
        private readonly IRepository<Authors> _userRepository;
        private object _AuthorsRepository;

        public AuthorsService(IConfiguration configuration, ILogger<BaseService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor,
              IRepository<Authors> AuthorsRepository
            )
            : base(configuration, logger, mapper, httpContextAccessor)
        {
            _AuthorsRepository = AuthorsRepository;
        }

        public List<AuthorsDto>? GetAll()
        {
            var entities = _AuthorsRepository.All();

            if (entities == null)
                return null;

            return Mapper.Map<List<AuthorsDto>>(entities);
        }
    }
}
