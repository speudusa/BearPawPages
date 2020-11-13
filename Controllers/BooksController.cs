using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BearPawPages.Data;
using BearPawPages.Models;
using BearPawPages.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace BearPawPages.Controllers
{
    public class BooksController : Controller

    {
        private BookDbContext context;

        public BooksController(BookDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Book> books = context.Books.ToList();

            return View(books);
        }

    //Creates book objects  *****************************

        [HttpGet] 
        public IActionResult Add()
        {
            AddBookViewModel addBookViewModel = new AddBookViewModel();
            return View(addBookViewModel);
        }

        [HttpPost] 
        public IActionResult Add(AddBookViewModel addBookViewModel)
        {
            if (ModelState.IsValid)
            {
                Book newBook = new Book
                {
                    Title = addBookViewModel.Title,
                    Author = addBookViewModel.Author,
                    TotalPage = addBookViewModel.TotalPage,
                    CurrentPage = addBookViewModel.CurrentPage,
                    ReadingDate = addBookViewModel.ReadingDate,
                    ReadingNotes = addBookViewModel.ReadingNotes
                };

                context.Books.Add(newBook);
                context.SaveChanges();


                return Redirect("/Books");
            }

            return View(addBookViewModel);

        }

    //Edit and EditBookData UPDATE ALL properties of book objects  *************************************
            //built PRIOR to presistent data

        [HttpGet]
        [Route("/Books/Edit/{bookId}")]//incorporating id into the route path 
        public IActionResult Edit(int bookId)  //identify specific book object
        {
            Book book = BookData.GetById(bookId);  //currently NOT using persistent Data.  
            ViewBag.book = book;  //using this to create reference object
            ViewBag.title = $"Edit Info for {book.Title}";
            return View();
        }

        [HttpPost]
        [Route("/Books/Edit")]
        public IActionResult EditBookData(int bookId, string title, string author, int totalPage, int currentPage, DateTime readingDate, string readingNotes)
        {
            Book book = BookData.GetById(bookId);  //making sure that same book object is being referenced 

            book.Title = title;  //listing like this will fill the boxes with the original input (which makes editing easier)
            book.Author = author;
            book.TotalPage = totalPage;
            book.CurrentPage = currentPage;
            book.ReadingDate = readingDate;
            book.ReadingNotes = readingNotes;

            context.SaveChanges();  //updating --this call is built for dB, but rest of method is not there
            return Redirect("/Books");  //back to list once updated
        }

   //Readbook and MoveBookMark UPDATE current page and date  *********************************
            [HttpGet]
            [Route("/Books/ReadBook/{bookId}")]
        public IActionResult ReadBook(int bookId)
        {
            Book book = context.Books.Find(bookId);
            ViewBag.book = book;
            ViewBag.title = $"Move Your Bookmark in {book.Title}";  //breaks here too

            return View();
            //review the transition in the LC book???
        }

            //https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/examining-the-edit-methods-and-edit-view
            //https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/updating-related-data-with-the-entity-framework-in-an-asp-net-mvc-application


        [HttpPost]
        [Route("/Books/ReadingTime/")]
        //still need to work on datetime >>Pin<<
        //not updating Data  Please review https://education.launchcode.org/csharp-web-development/chapters/orm-intro/background.html
        public IActionResult MoveBookMark(AddBookMarkViewModel addBookMarkViewModel)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book();
                book.Title = addBookMarkViewModel.Title;
                book.CurrentPage = addBookMarkViewModel.CurrentPage;
                book.ReadingDate = addBookMarkViewModel.ReadingDate;
                book.ReadingNotes = addBookMarkViewModel.ReadingNotes;
            }
            context.SaveChanges();
            return Redirect("/Books/");
        }

        
        [HttpGet]//GET
        public IActionResult Delete(AddBookViewModel addBookViewModel)
        {
            Book book = new Book();
            return View();
        }

        [HttpPost]
        public IActionResult DeleteBook(AddBookViewModel addBookViewModel)
        {
            if (ModelState.IsValid)
            {
                Book theBook = new Book();
                context.Books.Remove(theBook);
            }
            context.SaveChanges();
            return Redirect("/Books/");
        }
        
    }
}


//TODO:  
    // 1. View Models?  
    // 2. Play with formatting
    // 3. PERSISTENT DATA IS A MUST
