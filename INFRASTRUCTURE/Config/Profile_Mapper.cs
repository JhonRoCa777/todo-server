using AutoMapper;
using DOMAIN.Entities;
using INFRASTRUCTURE.Models;

namespace INFRASTRUCTURE.Config
{
    public class Profile_Mapper : Profile
    {
        public Profile_Mapper()
        {
            // USER
            CreateMap<User, UserModel>().ReverseMap();

            // TODO
            CreateMap<Todo, TodoModel>().ReverseMap();
            CreateMap<TodoRequest, TodoModel>();
        }
    }
}
