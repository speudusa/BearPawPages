using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BearPawPages.Data;
using BearPawPages.Models;
using Microsoft.AspNetCore.Mvc;

namespace BearPawPages.Controllers
{
    public class BooksController : Controller
    {
               
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.books = BookData.GetAll();

            return View();
        }

        [HttpGet]  //this DISPLAYS the form
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]  //Updates
        [Route("/Books/Add")]  //This is WHERE we will update

        public IActionResult NewBook(Book newBook)
        {
            BookData.Add(newBook);


            return Redirect("/Books");
        }

        //Edit and EditBookData UPDATE all properties of book objects
        //GET
        [Route("/Books/Edit/{bookId}")]
        public IActionResult Edit(int bookId)
        {
            Book book = BookData.GetById(bookId);
            ViewBag.book = book;
            ViewBag.title = $"Edit Book Info for {book.Title} (id={book.Id})";

            return View();
        }

        [HttpPost]
        [Route("/Books/Edit")]
        public IActionResult EditBookData(int bookId, string title, string author, int totalPage, int currentPage, DateTime readingDate, string readingNotes)
        {
            Book book = BookData.GetById(bookId);
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
            Book book = BookData.GetById(bookId);
            ViewBag.book = book;
            ViewBag.title = $"Move Your Bookmark in {book.Title}";
            return View();
        }

      
        [HttpPost]
        [Route("/Books/ReadingTime/")]
        public IActionResult MoveBookMark(int bookId,  int currentPage, string readingNotes)
        {
            Book book = BookData.GetById(bookId);
            book.CurrentPage = currentPage;
            //book.ReadingDate = readingDate;
            book.ReadingNotes = readingNotes;

            return Redirect("/Books/");
        }

        //GET
        public IActionResult Delete()
        {
            ViewBag.books = BookData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] bookIds)
        {
            foreach(int bookId in bookIds)
            {
                BookData.Remove(bookId);
            }
            
            return Redirect("/Books/");
        }
            

    }
}

//TODO:  
    // 1. View Models?  
    // 2. Play with formatting
    // 3. PERSISTENT DATA IS A MUST
