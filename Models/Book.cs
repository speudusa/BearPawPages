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

        public int Id { get; }
        private static int nextId = 1; //static counter variable




        public Book(string title, string author, int totalPage, int currentPage, DateTime readingDate, string readingNotes)
        {
            Id = nextId;
            nextId++;  //this will increment Id numbers as objects are added
            Title = title;
            Author = author;
            TotalPage = totalPage;
            CurrentPage = currentPage;
            ReadingDate = readingDate;
            ReadingNotes = readingNotes;
        }

        public override string ToString()
        {
            return Title;
        }
        public override bool Equals(object obj)
        {
            return obj is Book @book &&
                Id == book.Id;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
