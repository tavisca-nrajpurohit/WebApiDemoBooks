using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Data;

namespace WebApiDemo.Contracts
{
    public class Response
    {
        public Response(List<Book> itemlist, String err)
        {
            this.booklist = itemlist;
            this.message = err;
        }
        public List<Book> booklist { get; set; }
        public String message { get; set; }
    }
}
