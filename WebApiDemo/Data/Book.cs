using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Data
{
    public class Book
    {
        public int id { get; set; }
        public int price { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string category { get; set; }
    }
}
