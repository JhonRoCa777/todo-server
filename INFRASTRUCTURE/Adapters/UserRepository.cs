using APPLICATION.Ports.Output;
using AutoMapper;
using DOMAIN.Entities;
using DOMAIN.Exceptions.Types;
using INFRASTRUCTURE.Models;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Adapters
{
    public class UserRepository(AppDbContext Context, IMapper Mapper)
        : IUserRepository
    {
        private readonly AppDbContext _Context = Context;
        private readonly IMapper _Mapper = Mapper;

        public async Task<User> FindByCredentialsAsync(string Email, string Password)
        {
            var Result = await _Context.UserModel
                .Where(e => e.Email == Email)
                .FirstOrDefaultAsync() ?? throw new UserNotFoundException();

            if (Result.Deleted_At.HasValue)
                throw new UserNotActiveException();

            if (!BCrypt.Net.BCrypt.Verify(Password, Result.Password))
                throw new UserLoginNotFoundException();

            return _Mapper.Map<User>(Result);
        }
    }
}
