using Microsoft.EntityFrameworkCore;
using MyAppMSSQL.Library;
using MyAppMSSQL.Repositotyes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppMSSQL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = NOTEBOOK\SQLEXPRESS;Database=BooksLibrary;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
