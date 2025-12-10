using DOMAIN.Entities;

namespace APPLICATION.Ports.Input
{
    public interface IUserService
    {
        Task<User> FindByCredentialsAsync(string Email, string Password);
    }
}
