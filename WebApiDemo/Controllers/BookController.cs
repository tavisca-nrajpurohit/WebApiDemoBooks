using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiDemo.Model;
using WebApiDemo.Data;
using WebApiDemo.Contracts;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookService bookService = new BookService();

        // GET: api/Book
        [HttpGet]
        public Response Get()
        {
            return bookService.Get();
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public Response Get(int id)
        {
            return bookService.Get(id);
        }

        // POST: api/Book
        [HttpPost]
        public Response Post([FromBody] Book book)
        {
            return bookService.Post(book);
        }

        // PUT: api/Dummy/5
        [HttpPut("{id}")]
        public Response Put(int id, [FromBody] Book book)
        {
            return bookService.Put(id, book);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            return bookService.Delete(id);
        }
    }
}
