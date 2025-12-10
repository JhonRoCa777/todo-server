using DOMAIN.Entities;

namespace APPLICATION.Ports.Output
{
    public interface ITodoRepository
    {
        Task<List<Todo>> FindAllAsync(long UserId);

        Task<Todo> GetAsync(long Id);

        Task<Todo> CreateAsync(TodoRequest Request);

        Task<Todo> UpdateAsync(long Id, TodoRequest Request);

        Task<bool> DeleteAsync(long Id);
    }
}
