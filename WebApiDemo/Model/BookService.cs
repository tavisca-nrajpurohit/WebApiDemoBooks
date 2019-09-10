using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Data;
using WebApiDemo.Contracts;

namespace WebApiDemo.Model
{
    public class BookService : IServiceLayer
    {
        DataService dataClass = new DataService();
        

        public Response GenerateResponse(List<Book> itemList, String errorMessage, int statusCode)
        {
            Response response = new Response(itemList, errorMessage, statusCode);
            return response;
        }

        public Response Get()
        {
            return dataClass.Get();
        }

        public Response Get(int id)
        {
            if (isPositive(id))
            {
                return dataClass.Get(id);
            }
            else
            {
                return GenerateResponse(null, "Error: Invalid Book id, should be a positive number!",409);
            }
            
        }

        private bool isPositive(int id)
        {
            if(id>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Response Post(Book book)
        {
            if (isPositive(book.id) && isPositive(book.price))
            {
                if(isAlphabets(book.title) && isAlphabets(book.category) && isAlphabets(book.author))
                {
                    return dataClass.Post(book);
                }
                else
                {
                    return GenerateResponse(null, "Error: Invalid Book Title, Author or Category. Please use only Alphabets for them!",409);
                }
            }
            else
            {
                return GenerateResponse(null, "Error: Invalid Book ID or Price, they should be a positive number!",409);
            }
        }

        private bool isAlphabets(string str)
        {
            foreach (char c in str)
            {
                if (!Char.IsLetter(c) && c!=' ')
                    return false;
            }
            return true;
        }

        public Response Put(int id, Book book)
        {
            if(id != book.id)
            {
                return GenerateResponse(null, "Error: Please use the Same Book ID. Book ID cannot be changed!",409);
            }

            if (isPositive(book.id) && isPositive(book.price))
            {
                if (isAlphabets(book.title) && isAlphabets(book.category) && isAlphabets(book.author))
                {
                    return dataClass.Put(id,book);
                }
                else
                {
                    return GenerateResponse(null, "Error: Invalid Book Title, Author or Category. Please use only Alphabets for them!",409);
                }
            }
            else
            {
                return GenerateResponse(null, "Error: Invalid Book ID or Price, they should be a positive number!",409);
            }
        }

        public Response Delete(int id)
        {
            if (isPositive(id))
            {
                return dataClass.Delete(id);
            }
            else
            {
                return GenerateResponse(null, "Error: Invalid Book id, should be a positive number!",409);
            }
        }
       
    }
}
