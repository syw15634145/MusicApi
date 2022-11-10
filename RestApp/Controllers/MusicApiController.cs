using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicApiController : Controller
    {
        private List<Song> Songs = new List<Song> ()
        {
            new Song("All girls are the same", "Juice Wrld")
        };

        // GET: /<controller>/
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            Console.WriteLine(Songs);
            return Songs;
        }
    }
}

