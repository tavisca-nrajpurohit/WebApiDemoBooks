using System;
using System.Collections.Generic;
using WebApiDemo.Data;

namespace WebApiDemo.Contracts
{
    public class Response
    {
        public Response(List<Book> itemlist, String err, int status)
        {
            this.booklist = itemlist;
            this.message = err;
            this.statusCode = status;
        }
        public List<Book> booklist { get; set; }
        public String message { get; set; }
        public int statusCode { get; set; }
    }

}
