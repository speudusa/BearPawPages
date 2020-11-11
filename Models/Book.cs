using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearPawPages.Models
{
    public class Book
    {        
        public string Title { get; set; }

        public string Author { get; set; }

        public int TotalPage { get; set; }

        public int CurrentPage { get; set; }

        public DateTime ReadingDate { get; set; }

        public string ReadingNotes { get; set; }

        public int Id { get; set; }

        public Book()
        {
        }


        public Book(string title, string author, int totalPage, int currentPage, DateTime readingDate, string readingNotes)
        {
            Title = title;
            Author = author;
            TotalPage = totalPage;
            CurrentPage = currentPage;
            ReadingDate = readingDate;
            ReadingNotes = readingNotes;
        }

    }
}
