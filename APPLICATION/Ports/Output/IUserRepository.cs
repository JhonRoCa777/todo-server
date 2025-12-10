using DOMAIN.Entities;

namespace APPLICATION.Ports.Output
{
    public interface IUserRepository
    {
        Task<User> FindByCredentialsAsync(string Email, string Password);
    }
}
