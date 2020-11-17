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
                Book newBook = new Book  //what is this called? with {} instead of ();
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

        //initally build pre-presist data, so having trouble updating
        //CURRENTLY working on Edit and EditBookData Methods

        [HttpGet]
        [Route("/Books/Edit/{bookId}")]//incorporating id into the route path 
        public IActionResult Edit(AddBookViewModel addBookViewModel)  //identify specific book object
        {
            Book book = context.Books.Find(addBookViewModel.Id);
                 
            return View(book);
        }

        [HttpPost]
        [Route("/Books/Edit")]
        public IActionResult EditBookData(AddBookViewModel addBookViewModel)  //purpose:  to UPDATE ANY element of book object
        {
            Book book = context.Books.Find(addBookViewModel.Id);   //making sure that same book object is being referenced 

            book.Title = addBookViewModel.Title;  //want to be able to update input
            book.Author = addBookViewModel.Author;
            book.TotalPage = addBookViewModel.TotalPage;
            book.CurrentPage = addBookViewModel.CurrentPage;
            book.ReadingDate = addBookViewModel.ReadingDate;
            book.ReadingNotes = addBookViewModel.ReadingNotes;   

            context.SaveChanges();  //updating 
            return Redirect("/Books");  //back to list once updated
        }

   //Readbook and MoveBookMark UPDATE current page and date  *********************************
            [HttpGet]
            [Route("/Books/ReadBook/{bookId}")]
        public IActionResult ReadBook(int bookId)
        {
            Book book = context.Books.Find(bookId);
            
            return View(book);
        }


        [HttpPost]
        [Route("/Books/ReadingTime/")]
        public IActionResult MoveBookMark(AddBookViewModel addBookViewModel)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book();
                book.Title = addBookViewModel.Title;
                book.CurrentPage = addBookViewModel.CurrentPage;
                book.ReadingDate = addBookViewModel.ReadingDate;
                book.ReadingNotes = addBookViewModel.ReadingNotes;

            }
            context.SaveChanges();
            return Redirect("/Books/");
        }

        
        //************************ Delete methods  ********************************

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
