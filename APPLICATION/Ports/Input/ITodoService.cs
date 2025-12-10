using DOMAIN.Entities;

namespace APPLICATION.Ports.Input
{
    public interface ITodoService
    {
        Task<List<Todo>> FindAllAsync(long UserId);

        Task<Todo> GetAsync(long Id);

        Task<Todo> CreateAsync(TodoRequest Request);

        Task<Todo> UpdateAsync(long TodoId, TodoRequest Request);

        Task<bool> DeleteAsync(long TodoId);
    }
}
