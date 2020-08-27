using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CutApi.Models;

namespace cutapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CutController : ControllerBase
    {
        private static Cutter cutter = new Cutter();

        [HttpGet]
        public Message Get()
        {
            return new Message() { WelcomeMessage = "I am alive" };
        }

        [HttpPost]
        public List<CutResult> Post(CutItem todoItem)
        {
            var cutresult = cutter.Cut(todoItem);
            return cutresult;
        }
    }
}
