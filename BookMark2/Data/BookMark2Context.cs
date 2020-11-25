using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookMark2.Models;

namespace BookMark2.Data
{
    public class BookMark2Context : DbContext
    {
        public BookMark2Context (DbContextOptions<BookMark2Context> options)
            : base(options)
        {
        }

        public DbSet<BookMark2.Models.PersonalBookMark> PersonalBookMark { get; set; }
    }
}
