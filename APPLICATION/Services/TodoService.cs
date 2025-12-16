using APPLICATION.Ports.Input;
using APPLICATION.Ports.Output;
using DOMAIN.Entities;

namespace APPLICATION.Services
{
    public class TodoService(ITodoRepository Repo)
            : ITodoService
    {
        private readonly ITodoRepository _Repo = Repo;

        public async Task<List<Todo>> FindAllAsync(long UserId)
            => await _Repo.FindAllAsync(UserId);

        public async Task<Todo> GetAsync(long Id)
            => await _Repo.GetAsync(Id);

        public async Task<List<TodoGroup>> GetGroupAsync(long UserId)
            => await _Repo.GetGroupAsync(UserId);

        public async Task<Todo> CreateAsync(TodoRequest Request, long UserId)
            => await _Repo.CreateAsync(Request, UserId);

        public async Task<Todo> UpdateAsync(long Id, TodoRequest Request)
            => await _Repo.UpdateAsync(Id, Request);

        public async Task<bool> DeleteAsync(long Id)
            => await _Repo.DeleteAsync(Id);
    }
}
