using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiDemo.Contracts;
using WebApiDemo.Data;
using WebApiDemo.Model;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookService bookService = new BookService();
        private readonly IValidator<Book> _bookValidator;
        private readonly IValidator<int> _idValidator;

        public BookController(IValidator<Book> bookValidator, IValidator<int> idValidator)
        {
            _bookValidator = bookValidator;
            _idValidator = idValidator;
        }

        // GET: api/Book
        [HttpGet]
        public ActionResult<Response> Get()
        {
            Response response = bookService.Get();
            return StatusCode(response.statusCode, response);
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Response> Get(int id)
        {
            var validationResult = _idValidator.Validate(id);
            List<string> response_message = new List<string>();

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    response_message.Add(error.ToString());
                return StatusCode(400, response_message);
            }
            else
            {
                Response response = bookService.Get(id);
                return StatusCode(response.statusCode, response);
            }

        }

        // POST: api/Book
        [HttpPost]
        public ActionResult<Response> Post([FromBody] Book book)
        {
            var validationResult = _bookValidator.Validate(book);
            List<string> response_message = new List<string>();

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    response_message.Add(error.ToString());
                return StatusCode(400, response_message);
            }
            else
            {
                Response response = bookService.Post(book);
                return StatusCode(response.statusCode, response);
            }

        }

        // PUT: api/Dummy/5
        [HttpPut("{id}")]
        public ActionResult<Response> Put(int id, [FromBody] Book book)
        {
            var validationResult = _bookValidator.Validate(book);
            List<string> response_message = new List<string>();

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    response_message.Add(error.ToString());
                return StatusCode(400, response_message);
            }
            else
            {
                Response response = bookService.Put(id, book);
                return StatusCode(response.statusCode, response);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Response> Delete(int id)
        {
            var validationResult = _idValidator.Validate(id);
            List<string> response_message = new List<string>();

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    response_message.Add(error.ToString());
                return StatusCode(400, response_message);
            }
            else
            {
                Response response = bookService.Delete(id);
                return StatusCode(response.statusCode, response);
            }

        }
    }
}
