using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Data;

namespace WebApiDemo.Contracts
{
    interface IServiceLayer
    {
        Response Get();
        Response Get(int id);
        Response Put(int id, Book book);
        Response Post(Book book);
        Response Delete(int id);
    }

    interface IDataLayer
    {
        Response Get();
        Response Get(int id);
        Response Put(int id, Book book);
        Response Post(Book book);
        Response Delete(int id);
    }
}
