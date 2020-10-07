using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BearPawPages.Models;
using Microsoft.AspNetCore.Mvc;

namespace BearPawPages.Controllers
{
    public class BooksController : Controller
    {
        static private List<Book> Books = new List<Book>();
        
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.books = Books;

            return View();
        }

        [HttpGet]  //this DISPLAYS the form
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]  //Updates
        [Route("/Books/Add")]  //This is WHERE we will update

        public IActionResult NewBook(string title, string author, int totalPage, int currentPage, DateTime readingDate, string readingNotes)
        {
            Books.Add(new Book (title, author, totalPage, currentPage, readingDate, readingNotes));

            return Redirect("/Books");
        }

    }
}

//TODO:  Pick up at 14.3 Models & Data