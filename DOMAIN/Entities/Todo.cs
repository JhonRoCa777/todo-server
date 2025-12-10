using DOMAIN.Enums;

namespace DOMAIN.Entities
{
    public record Todo(
        long Id,
        string Description,
        Estado Estado,
        string Created_At,
        string? Deleted_At
    )
    { }

    public record TodoRequest(
        string Description
    )
    { }
}
