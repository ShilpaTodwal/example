using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_WEBAPI_CORE.Models;
using MVC_WEBAPI_CORE.Models.DTO;

namespace MVC_WEBAPI_CORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ToDoItems1Controller : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public ToDoItems1Controller(TodoContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;

        }

        // GET: api/ToDoItems1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetTodoItems()
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            var list_items=await _context.TodoItems.ToListAsync();
            var list_items_dto = _mapper.Map<List<GetTodolist>>(list_items);
            return Ok(list_items_dto);  
        }

        // GET: api/ToDoItems1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(long id)
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            var toDoItem = await _context.TodoItems.FindAsync(id);
            var list_item_dto = _mapper.Map<GetTodolist>(toDoItem);
            return Ok(list_item_dto);

           }

        // PUT: api/ToDoItems1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(long id, GetTodolist toDo_DTO)
        {
            if (id != toDo_DTO.Id)
            {
                return BadRequest();
            }
            var toDoItem = await this._context.TodoItems.FindAsync(id);

            if (toDoItem == null)
            {
                throw new Exception($"TodoItem {id} is not found.");
            }

            this._mapper.Map(toDo_DTO, toDoItem);

            var result = this._context.TodoItems.Update(toDoItem);

            await this._context.SaveChangesAsync();

            return Ok();
           

           
        }

        // POST: api/ToDoItems1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(GetTodolist toDoItemDTO)
        {
          if (_context.TodoItems == null)
          {
              return Problem("Entity set 'TodoContext.TodoItems'  is null.");
          }
            var list_item = _mapper.Map<ToDoItem>(toDoItemDTO);

            _context.TodoItems.Add(list_item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoItem", new { id = toDoItemDTO.Id }, toDoItemDTO);
        }

        // DELETE: api/ToDoItems1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(long id)
        {
            if (_context.TodoItems == null)
            {
                return NotFound();
            }
            var toDoItem = await _context.TodoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoItemExists(long id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
