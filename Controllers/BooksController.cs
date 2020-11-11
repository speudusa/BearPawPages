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

        [HttpGet]  //this DISPLAYS the form
        public IActionResult Add()
        {
            AddBookViewModel addBookViewModel = new AddBookViewModel();
            return View(addBookViewModel);
        }

        [HttpPost]  //PROCESSES form
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

        //Edit and EditBookData UPDATE ALL properties of book objects
        //GET
        [Route("/Books/Edit/{bookId}")]

        public IActionResult Edit(int bookId)
        {
            Book book = context.Books.Find(bookId);
            ViewBag.book = book;
            ViewBag.title = $"Edit Book Info for {book.Title} (id={book.Id})";

            return View();
        }

        //TODO: Work on this method.  Once this one is working, 
        //apply it to the BookMark method
        [HttpPost]
        [Route("/Books/Edit")]
        public IActionResult EditBookData(EditBookViewModel editBookViewModel)
        {
            //want to be able to replace any data element in this edit method
            //Need to be able to apply to correct object (id)
            
                Book book = context.Books.Find(editBookViewModel.Id);
                book.Title = editBookViewModel.Title;   //breaks here
                book.Author = editBookViewModel.Author;
                book.TotalPage = editBookViewModel.TotalPage;
                book.CurrentPage = editBookViewModel.CurrentPage;
                book.ReadingDate = editBookViewModel.ReadingDate;
                book.ReadingNotes = editBookViewModel.ReadingNotes;

                context.SaveChanges();
                return Redirect("/Books");

        }

            //Readbook and MoveBookMark UPDATE current page and date 
            [HttpGet]
            [Route("/Books/ReadBook/{bookId}")]
        public IActionResult ReadBook(AddBookMarkViewModel addBookMarkViewModel)
        {
            Book book = context.Books.Find(addBookMarkViewModel.Id);
            ViewBag.book = book;
            ViewBag.title = $"Move Your Bookmark in {book.Title}";

            return View();
        }

            //https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/examining-the-edit-methods-and-edit-view
            //https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/updating-related-data-with-the-entity-framework-in-an-asp-net-mvc-application


        [HttpPost]
        [Route("/Books/ReadingTime/")]
            //still need to work on datetime >>Pin<<
            //not updating Data
        public  IActionResult MoveBookMark(AddBookMarkViewModel addBookMarkViewModel)
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
