using BearPawPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearPawPages.Data
{
    public class BookData
    {
        //store books
        private static Dictionary<int, Book> Books = new Dictionary<int, Book>();

        //add a book
        public static void Add(Book newBook)
        {
            Books.Add(newBook.Id, newBook);
        }

        //retreive ALL of the books
        public static IEnumerable<Book> GetAll()
        {
            return Books.Values;
                //only returning the book objects themselves, not the list
        }

        //retreive a single book
        public static Book GetById(int id)
        {
            return Books[id];
        }

        //remove book
        public static void Remove(int id)
        {
            Books.Remove(id);
        }

    }
}

//purpose = house book collection and define what can be done to/with our collection