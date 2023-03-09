using Microsoft.EntityFrameworkCore.Storage;
using MyAppMSSQL;
using MyAppMSSQL.Library;

public class Program
{
    static void Main(string[] args)
    {
        using (var db = new ApplicatuonContext())
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var user1 = new User { Name = "Максим", Email = "max@mail.com" };
            var user2 = new User { Name = "Bob", Email = "bob@mail.com" };
            var user3 = new User { Name = "Кристина", Email = "krist@mail.com" };

            db.Users.AddRange(new[] { user1, user2, user3 });

            var book1 = new Book { Title = "Harry Potter", Autor = "Joan Rolling", Date = 1999/04/14, Genre = "Fantastic" };
            var book2 = new Book { Title = "Гроздья гнева", Autor = "Джон Стейнбек", Date = 1939 / 01 / 01, Genre = "Роман" };
            var book3 = new Book { Title = "Война и мир", Autor = "Лев Николаевич Толстой", Date = 1863 / 01 / 01, Genre = "Роман" };
            var book4 = new Book { Title = "Гамлет", Autor = "Шекспир", Date = 1599 / 01 / 01, Genre = "Трагедия" };

            db.Books.AddRange(new[] { book1, book2, book3, book4 });
            
            db.SaveChanges();
        }
    }
}