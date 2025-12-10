using APPLICATION.Ports.Output;
using AutoMapper;
using DOMAIN.Entities;
using DOMAIN.Exceptions.Types;
using INFRASTRUCTURE.Models;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Adapters
{
    public class TodoRepository(AppDbContext Context, IMapper Mapper)
        : ITodoRepository
    {
        private readonly AppDbContext _Context = Context;
        private readonly IMapper _Mapper = Mapper;

        public async Task<List<Todo>> FindAllAsync(long UserId)
        {
            var Result = await _Context.TodoModel
                                        .Where(e => e.UserId == UserId)
                                        .Where(e => e.Deleted_At == null)
                                        .OrderByDescending(e => e.Id)
                                        .ToListAsync();

            return _Mapper.Map<List<Todo>>(Result);
        }

        public async Task<Todo> GetAsync(long Id)
        {
            var Result = await this.FindAsync(Id);
            return _Mapper.Map<Todo>(Result);
        }

        public async Task<Todo> CreateAsync(TodoRequest Request)
        {
            var Result = _Mapper.Map<TodoModel>(Request);

            await _Context.TodoModel.AddAsync(Result);
            await _Context.SaveChangesAsync();

            return _Mapper.Map<Todo>(Result);
        }

        public async Task<Todo> UpdateAsync(long Id, TodoRequest Request)
        {
            var Result = await this.FindAsync(Id);

            _Mapper.Map(Request, Result);
            await _Context.SaveChangesAsync();

            return _Mapper.Map<Todo>(Result);
        }

        public async Task<bool> DeleteAsync(long Id)
        {
            var Result = await this.FindAsync(Id);

            Result.Deleted_At = DateTime.Now;
            await _Context.SaveChangesAsync();

            return true;
        }

        /************************************** CUSTOM **************************************/

        private async Task<TodoModel> FindAsync(long TodoId)
        {
            var Result = await _Context.TodoModel
                .Where(e => e.Id == TodoId)
                .FirstOrDefaultAsync() ?? throw new TodoNotFoundException();

            if (Result.Deleted_At.HasValue)
                throw new TodoNotActiveException();

            return Result;
        }
    }
}
