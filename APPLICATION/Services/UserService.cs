using APPLICATION.Ports.Input;
using APPLICATION.Ports.Output;
using DOMAIN.Entities;

namespace APPLICATION.Services
{
    public class UserService(IUserRepository Repo)
            : IUserService
    {
        private readonly IUserRepository _Repo = Repo;

        public async Task<User> FindByCredentialsAsync(string Email, string Password)
            => await _Repo.FindByCredentialsAsync(Email, Password);
    }
}
