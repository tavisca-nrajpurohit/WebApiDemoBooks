using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Contracts;

namespace WebApiDemo.Data
{
    public class DataService : IDataLayer
    {
        List<Book> bookList = new List<Book>();
        String jsonFileName = @"C:\Users\nrajpurohit\source\repos\WebApiDemo\WebApiDemo\BookData.json";

        public DataService()
        {
            LoadJson();
        }
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(jsonFileName))
            {
                string json = r.ReadToEnd();
                bookList = JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }

        public Response GenerateResponse(List<Book> itemList, String errorMessage)
        {
            Response response = new Response(itemList,errorMessage);
            return response;
        }

        public Response Get()
        {
            return GenerateResponse(bookList,null);
        }

        public Response Get(int id)
        {
            foreach (Book book in bookList)
            {
                if (book.id == id)
                {
                    List<Book> itemlist = new List<Book>();
                    itemlist.Add(book);
                    return GenerateResponse(itemlist,null);
                }
            }
            return GenerateResponse(null,"Error: No such Book Found in the Repository");
        }

        public Response Put(int id, Book book)
        {
            foreach (Book item in bookList)
            {
                if (item.id == id)
                {
                    bookList.Remove(item);
                    bookList.Add(book);

                    string jsonStr = JsonConvert.SerializeObject(bookList.ToArray());
                    System.IO.File.WriteAllText(jsonFileName, jsonStr);
                    return GenerateResponse(null,"Data Updated Successfully!");
                }
            }
            return GenerateResponse(null, "Error: Could not update Data. Book with this ID was not found!");
            
        }

        public Response Post(Book book)
        {
            bool BookIdIsUnique = true;

            foreach (Book item in bookList)
            {
                if (item.id == book.id)
                {
                    BookIdIsUnique = false;
                }
            }

            if (BookIdIsUnique)
            {
                bookList.Add(book);
                string jsonStr = JsonConvert.SerializeObject(bookList.ToArray());
                System.IO.File.WriteAllText(jsonFileName, jsonStr);
                return GenerateResponse(null, "Data Added Successfully !") ;
            }
            else
            {
                return GenerateResponse(null, "Error: Could not add data. | Reason: Book Id should be unique!");
            }
        }

        public Response Delete(int id)
        {
            foreach (Book book in bookList)
            {
                if (book.id == id)
                {
                    bookList.Remove(book);
                    string jsonStr = JsonConvert.SerializeObject(bookList.ToArray());
                    System.IO.File.WriteAllText(jsonFileName, jsonStr);
                    return GenerateResponse(null, "Data Deleted Successfully !");
                }
            }
            return GenerateResponse(null, "Error: No such Book Found in the Repository");
        }
    }
}
