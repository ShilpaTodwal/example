namespace MVC_WEBAPI_CORE.Models.DTO
{
    public class GetTodolist
    {


        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
