using AutoMapper;
using MVC_WEBAPI_CORE.Models;
using MVC_WEBAPI_CORE.Models.DTO;

namespace MVC_WEBAPI_CORE.Mapper
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
            CreateMap<ToDoItem,
                GetTodolist>().ReverseMap();
        }
    }
}
