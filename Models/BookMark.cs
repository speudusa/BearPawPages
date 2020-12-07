using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearPawPages.Models
{
    public class BookMark 
    {
        public string Title { get; set; }

        public int CurrentPage { get; set; }  //I want to update this

        public  DateTime ReadingDate { get; set; } //update this

        public string ReadingNotes { get; set; }  //update this

        public BookMark()
        { 
        }

        public BookMark(string title, int currentPage, string readingNotes, DateTime readingDate)
        {
            Title = title;  //for reference on H1 tag
            CurrentPage = currentPage;  //updating
            ReadingDate = readingDate;  //updating
            ReadingNotes = readingNotes;  //updating
        }
    }

  
}
