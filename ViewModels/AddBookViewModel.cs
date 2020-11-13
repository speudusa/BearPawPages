using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BearPawPages.ViewModels
{
    public class AddBookViewModel
    {
        [Required(ErrorMessage ="Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author name is required.")]
        public string Author { get; set; }

       [Required(ErrorMessage = "Total page number is required.")]
        public int TotalPage { get; set; }

        [Required(ErrorMessage = "Current page number is required.")]
        public int CurrentPage { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime ReadingDate { get; set; }

        public string ReadingNotes { get; set; }


        public int Id { get; set; }


    }
}
