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
           if(ModelState.IsValid)
            {
                Book newBook = new Book
                {
                    Title = addBookViewModel.Title,
                    Author = addBookViewModel.Author,
                    TotalPage = addBookViewModel.TotalPage,
                    CurrentPage = addBookViewModel.CurrentPage,
                    //ReadingDate = addBookViewmodel.ReadingDate,
                    ReadingNotes = addBookViewModel.ReadingNotes
                };

                context.Books.Add(newBook);
                context.SaveChanges();


                return Redirect("/Books");
            }

            return View(addBookViewModel);

        }

        //Edit and EditBookData UPDATE all properties of book objects
        //GET
        [Route("/Books/Edit/{bookId}")]
        public IActionResult Edit(int bookId)
        {
            Book book = context.Books.Find(bookId);
            ViewBag.book = book;
            ViewBag.title = $"Edit Book Info for {book.Title} (id={book.Id})";

            return View();
        }

        [HttpPost]
        [Route("/Books/Edit")]
        public IActionResult EditBookData(int bookId, string title, string author, int totalPage, int currentPage, DateTime readingDate, string readingNotes)
        {
            Book book = context.Books.Find(bookId);
            book.Title = title;
            book.Author = author;
            book.TotalPage = totalPage;
            book.CurrentPage = currentPage;
            book.ReadingDate = readingDate;
            book.ReadingNotes = readingNotes;

            return Redirect("/Books");
        }

        //Readbook and MoveBookMark UPDATE current page and date 
        [HttpGet]
        [Route("/Books/ReadBook/{bookId}")]
        public IActionResult ReadBook(int bookId)
        {
            Book book = context.Books.Find(bookId);
            ViewBag.book = book;
            ViewBag.title = $"Move Your Bookmark in {book.Title}";
 
            return View();
        }

        //**************** AAAAAAAAAAAAAAHHHHHHHHHHHHHH!***************
        //TODO:  trying to update the Edit function
        //https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/examining-the-edit-methods-and-edit-view
        //https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/updating-related-data-with-the-entity-framework-in-an-asp-net-mvc-application


        [HttpPost]
        [Route("/Books/ReadingTime/")]
        public IActionResult MoveBookMark(AddBookViewModel addBookViewModel)
        {
            foreach (int bookId in bookIds)
            {
                Book bookMark = context.Books.Find(bookId)
                { 
                    CurrentPage = context.Books.Add(addBookViewModel.CurrentPage),
                //book.ReadingDate = readingDate,
                context.Books.ReadingNotes = readingNotes,
            
            }

            return Redirect("/Books/");
        }

        //GET
        public IActionResult Delete()
        {
            ViewBag.books = context.Books.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] bookIds)
        {
            foreach(int bookId in bookIds)
            {
                Book theBook = context.Books.Find(bookId);
                context.Books.Remove(theBook);
            }
            
            return Redirect("/Books/");
        }
            

    }
}

//TODO:  
    // 1. View Models?  
    // 2. Play with formatting
    // 3. PERSISTENT DATA IS A MUST
