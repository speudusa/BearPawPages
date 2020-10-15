using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using BearPawPages.Data;
using BearPawPages.Models;
using BearPawPages.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BearPawPages.Controllers
{
    public class ReaderController : Controller
    {
        private BookDbContext context;

        public ReaderController(BookDbContext dbContext)
        {
            context = dbContext;
        }

        [Route("Reader/Index")]
        public IActionResult Index()
        {
            List<Reader> readers = context.Readers.ToList();

            return View(readers);
        }

        //GET Add Method
        [HttpGet]
        public IActionResult CreateReader()
        {
            AddReaderViewModel addReaderViewModel = new AddReaderViewModel();
            return View(addReaderViewModel);
        }

        //POST
        [HttpPost]
        public IActionResult ProcessCreateReaderForm(AddReaderViewModel addReaderViewModel)
        {
            if(ModelState.IsValid)
            {
                Reader newReader = new Reader
                {
                    ReaderName = addReaderViewModel.ReaderName
                };

                context.Readers.Add(newReader);
                context.SaveChanges();

                return Redirect("/Reader");
            }

            return View("Create", addReaderViewModel);
            
            
        }
    }
}
