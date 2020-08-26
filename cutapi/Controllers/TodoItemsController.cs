using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace cutapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        private Cutter cutter = new Cutter();

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public string GetTodoItems()
        {
            return "Hello cutter";
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        //public async Task<ActionResult<List<CutResult>>> PostTodoItem(TodoItem todoItem)
        public List<CutResult> PostTodoItem(TodoItem todoItem)
        {
            var res = cutter.DoStuff(todoItem);
            return res;
        }
    }
}
