using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THWEB_LAP23.Models;

namespace THWEB_LAP23.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()         
        {

            var books = new List<string>();
         books.Add("HTLM5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTLM5 & CSS3 Responsive web Design cookbook - Author Name Book 2");
            books.Add("Professional APS.NET  MVC5 - Author Name Book 3");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {

            var books = new List<Book>();
            books.Add(new Book(1, "HTLM5 & CSS3 The complete Manual","Author Name Book 1", "/Content/images/hinh1.jpg"));
            books.Add(new Book(2, "HTLM5 & CSS3 Responsive web Design cookbook "," Author Name Book 2", "/Content/images/hinh2.jpg"));
            books.Add(new Book(3, "Professional APS.NET  MVC5 "," Author Name Book 3", "/Content/images/hinh3.jpg"));
            return View(books);
        }


        public ActionResult EditBook(int id)
        {

            var books = new List<Book>();
            books.Add(new Book(1, "HTLM5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/hinh1.jpg"));
            books.Add(new Book(2, "HTLM5 & CSS3 Responsive web Design cookbook ", " Author Name Book 2", "/Content/images/hinh2.jpg"));
            books.Add(new Book(3, "Professional APS.NET  MVC5 ", " Author Name Book 3", "/Content/images/hinh3.jpg"));

            Book book = new Book();
            foreach (Book b in books)
            {
                if( b.Id==id)
                {
                    book = b;
                    break;
                }
            }
            if(book == null )
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost , ActionName("EditBook")]
        [ValidateAntiForgeryToken]

        public ActionResult EditBook (int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTLM5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/hinh1.jpg"));
            books.Add(new Book(2, "HTLM5 & CSS3 Responsive web Design cookbook ", " Author Name Book 2", "/Content/images/hinh2.jpg"));
            books.Add(new Book(3, "Professional APS.NET  MVC5 ", " Author Name Book 3", "/Content/images/hinh3.jpg"));
            if (id==null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if(b.Id == id )
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel", books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact ([Bind(Include ="id , Title ,Author , ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTLM5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/hinh1.jpg"));
            books.Add(new Book(2, "HTLM5 & CSS3 Responsive web Design cookbook ", " Author Name Book 2", "/Content/images/hinh2.jpg"));
            books.Add(new Book(3, "Professional APS.NET  MVC5 ", " Author Name Book 3", "/Content/images/hinh3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    //them moi ds
                    books.Add(book);
                }
            }
            catch(RetryLimitExceededException /* dex*/)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            //tra ve tranhg xem sach
            return View("ListBookModel", books);
        }
    }
}