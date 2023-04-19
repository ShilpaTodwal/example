using MVC_WEBAPI_CORE.Models;
namespace MVC_WEBAPI_CORE.Models
{
    public class ToDoItem
    {


        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

    }


}
