using DOMAIN.Entities;

namespace APPLICATION.Ports.Output
{
    public interface ITodoRepository
    {
        Task<List<Todo>> FindAllAsync(long UserId);

        Task<Todo> GetAsync(long Id);

        Task<List<TodoGroup>> GetGroupAsync(long UserId);

        Task<Todo> CreateAsync(TodoRequest Request, long UserId);

        Task<Todo> UpdateAsync(long Id, TodoRequest Request);

        Task<bool> DeleteAsync(long Id);
    }
}
