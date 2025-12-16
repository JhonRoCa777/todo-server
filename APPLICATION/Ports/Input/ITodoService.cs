using DOMAIN.Entities;

namespace APPLICATION.Ports.Input
{
    public interface ITodoService
    {
        Task<List<Todo>> FindAllAsync(long UserId);

        Task<Todo> GetAsync(long Id);

        Task<List<TodoGroup>> GetGroupAsync(long UserId);

        Task<Todo> CreateAsync(TodoRequest Request, long UserId);

        Task<Todo> UpdateAsync(long TodoId, TodoRequest Request);

        Task<bool> DeleteAsync(long TodoId);
    }
}
