using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BearPawPages.Controllers
{
    public class BooksController : Controller
    {
        static private List<string> Books = new List<string>();
        
        [HttpGet]
        public IActionResult Index()
        {
            Books.Add("Pumpkin Soup");
            Books.Add("Mr. Putter Paints the Porch");
            Books.Add("Podkin One Ear");
            ViewBag.books = Books;

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


    }
}
