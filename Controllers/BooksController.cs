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

        public IActionResult NewBook(string title, string author, int totalPage, int currentPage, DateTime readingDate, string readingNotes)
        {
            BookData.Add(new Book (title, author, totalPage, currentPage, readingDate, readingNotes));

            return Redirect("/Books");
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

//TODO:  Pick up at 14.4 Models & Data