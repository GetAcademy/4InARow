using System;
using System.Collections.Generic;
using _4InARow.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _4InARow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET: api/<GameController>
        [HttpGet("{id}")]
        public Game Get(int id)
        {
            return null;
        }

        // POST api/<GameController>
        [HttpPost]
        public Game Start()
        {
            return new Game(){Id = 7};
        }

        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
        }
    }
}
