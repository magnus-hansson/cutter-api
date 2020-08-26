using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Threading.Tasks;
namespace cutapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {


        private Cutter cutter = new Cutter();



        // GET: api/TodoItems
        [HttpGet]
        public Dummy GetTodoItems()
        {
            //return "Hello cutterzx";
            return new Dummy() { Message = "Yolo" };
        }


        [HttpPost]
        public List<CutResult> PostTodoItem(TodoItem todoItem)
        {
            var res = cutter.DoStuff(todoItem);
            return res;
        }
    }
}
