using BearPawPages.Models;
using BearPawPages.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearPawPages.Data
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Reader> Readers { get; set; }

        public BookDbContext(DbContextOptions<BookDbContext> options) 
            : base(options)
        {
        }

        internal void SaveChanges(EditBookViewModel editBookViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
