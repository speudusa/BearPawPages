using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearPawPages.Models
{
    public class BookMark : Book
    {

        public int CurrentPage { get; set; }  //I want to update this

        public DateTime ReadingDate { get; set; } //update this

        public string ReadingNotes { get; set; }  //update this

        public BookMark()
        { 
        }

        public BookMark(int id, string title, int currentPage, string readingNotes, DateTime readingDate)
        {
            Id = id;  //inheriting
            Title = title; //inheriting
            CurrentPage = currentPage;  //updating
            ReadingDate = readingDate;  //updating
            ReadingNotes = readingNotes;  //updating
        }
    }

  
}
