using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookmarkContext : DbContext
    {
        public BookmarkContext() : base ("BMSConnection")
        {

        }

        public DbSet<Bookmark> Bookmarks { get; set; }    
    } 
}
