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
        public ActionResult<Response> Get()
        {
            Response response =  bookService.Get();
            return StatusCode(response.statusCode, response);
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Response> Get(int id)
        {
            Response response = bookService.Get(id);
            return StatusCode(response.statusCode, response);
        }

        // POST: api/Book
        [HttpPost]
        public ActionResult<Response> Post([FromBody] Book book)
        {
            Response response = bookService.Post(book);
            return StatusCode(response.statusCode, response);
        }

        // PUT: api/Dummy/5
        [HttpPut("{id}")]
        public ActionResult<Response> Put(int id, [FromBody] Book book)
        {
            Response response = bookService.Put(id, book);
            return StatusCode(response.statusCode, response);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Response> Delete(int id)
        {
            Response response = bookService.Delete(id);
            return StatusCode(response.statusCode, response);
        }
    }
}
