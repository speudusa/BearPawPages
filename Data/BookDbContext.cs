using BearPawPages.Models;
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
    }
}
