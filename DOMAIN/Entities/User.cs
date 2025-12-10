using DOMAIN.Enums;

namespace DOMAIN.Entities
{
    public record User(
        long Id,
        string Fullname,
        string Email,
        string Password,
        Role Role,
        string Created_At,
        string? Deleted_At
    )
    { }

    public record UserLogin(
        string Email,
        string Password
    )
    { }
}
