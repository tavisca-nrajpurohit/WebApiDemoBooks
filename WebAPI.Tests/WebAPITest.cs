using System;
using Xunit;
using WebApiDemo.Contracts;
using WebApiDemo.Data;
using WebApiDemo.Model;
using WebApiDemo.Controllers;
using WebApiDemo.Contracts;
using System.Collections.Generic;

namespace WebAPI.Tests
{
    public class WebAPITest
    {
        BookService bookservice = new BookService();

        [Fact]
        public void Get_Without_Parameters_Test()
        {
            Response response = bookservice.Get();
            List<Book> booklist = response.booklist;

            Assert.True(booklist.Count > 0);
        }

        [Fact]
        public void Get_With_Parameters_Test_All_Favourable_Inputs()
        {
            Response response = bookservice.Get(1);
            List<Book> booklist = response.booklist;

            Assert.True(booklist.Count == 1);
        }

        [Fact]
        public void Get_With_Parameters_Test_Negative_BOOK_ID_Input()
        {
            Response response = bookservice.Get(-1);
            List<Book> booklist = response.booklist;
            string msg = response.message;
            
            Assert.Equal("Error: Invalid Book id, should be a positive number!", msg);
        }

        [Fact]
        public void Get_With_Parameters_Test_No_Data_Found()
        {
            Response response = bookservice.Get(999);
            List<Book> booklist = response.booklist;
            string msg = response.message;
            
            Assert.Equal("Error: No such Book Found in the Repository", msg);
        }

        [Fact]
        public void POST_With_Everything_Good()
        {
            Book book = new Book() { id =15,price=140,title="Book twelve",author="Neelesh ji",category="Fiction"};
            Response response = bookservice.Post(book);
            List<Book> booklist = response.booklist;
            string msg = response.message;

            Assert.Equal("Data Added Successfully !", msg);
            response = bookservice.Delete(15);
        }

        [Fact]
        public void POST_Input_with_negetive_Id_and_price()
        {
            Book book = new Book() { id = -1, price = -140, title = "Book twelve", author = "Neelesh ji", category = "Fiction" };
            Response response = bookservice.Post(book);
            List<Book> booklist = response.booklist;
            string msg = response.message;
            Assert.Equal("Error: Invalid Book ID or Price, they should be a positive number!", msg);
        }

        [Fact]
        public void POST_Input_With_NON_ALphabet_Book_Title()
        {
            Book book = new Book() { id = 12, price = 40, title = "Book 2twelve", author = "Neelesh2 ji", category = "2Fiction" };
            Response response = bookservice.Post(book);
            List<Book> booklist = response.booklist;
            string msg = response.message;
            Assert.Equal("Error: Invalid Book Title, Author or Category. Please use only Alphabets for them!", msg);
        }

        [Fact]
        public void POST_Input_with_Existing_Book_Id()
        {
            Book book = new Book() { id = 1, price = 40, title = "Book twelve", author = "Neelesh ji", category = "Fiction" };
            Response response = bookservice.Post(book);
            List<Book> booklist = response.booklist;
            string msg = response.message;
            Assert.Equal("Error: Could not add data. | Reason: Book Id should be unique!", msg);
        }

        [Fact]
        public void PUT_Change_In_Book_Id()
        {
            Book book = new Book() { id = 12, price = 140, title = "Book twelve", author = "Neelesh ji", category = "Fiction" };
            Response response = bookservice.Put(1,book);
            List<Book> booklist = response.booklist;
            string msg = response.message;

            Assert.Equal("Error: Please use the Same Book ID. Book ID cannot be changed!", msg);
        }


        [Fact]
        public void PUT_Input_with_negetive_Id_and_price()
        {
            Book book = new Book() { id = 1, price = -140, title = "Book twelve", author = "Neelesh ji", category = "Fiction" };
            Response response = bookservice.Put(1, book);
            List<Book> booklist = response.booklist;
            string msg = response.message;

            Assert.Equal("Error: Invalid Book ID or Price, they should be a positive number!", msg);
        }

        [Fact]
        public void PUT_Input_With_NON_ALphabet_Book_Title()
        {
            Book book = new Book() { id = 1, price = 140, title = "1 Book twelve", author = "1 Neelesh ji", category = "Fiction" };
            Response response = bookservice.Put(1, book);
            List<Book> booklist = response.booklist;
            string msg = response.message;

            Assert.Equal("Error: Invalid Book Title, Author or Category. Please use only Alphabets for them!", msg);
        }

        [Fact]
        public void DELETE_Input_with_negative_Id()
        {
            Response response = bookservice.Delete(-2);
            List<Book> booklist = response.booklist;
            string msg = response.message;

            Assert.Equal("Error: Invalid Book id, should be a positive number!", msg);
        }

        [Fact]
        public void DELETE_Successful()
        {
            Book book = new Book() { id = 22, price = 140, title = "Book twelve", author = "Neelesh ji", category = "Fiction" };
            Response response = bookservice.Post(book);

            response = bookservice.Delete(22);
            List<Book> booklist = response.booklist;
            string msg = response.message;
            Assert.Equal("Data Deleted Successfully !", msg);
        }

        [Fact]
        public void DELETE_No_Record_Found_To_Be_Deleted()
        {
            Response response = bookservice.Delete(999);
            List<Book> booklist = response.booklist;
            string msg = response.message;
            Assert.Equal("Error: No such Book Found in the Repository", msg);
        }



    }
}
