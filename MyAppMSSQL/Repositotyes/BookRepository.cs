using Microsoft.EntityFrameworkCore;
using MyAppMSSQL.Library;

namespace MyAppMSSQL.Repositotyes
{
    /// <summary>
    /// Репозторий для работы с книгой
    /// </summary>
    public class BookRepository
    {       
        /// <summary>
        /// Метод для выбора книги по Id
        /// </summary>
        /// <param name="id"></param>
        public void BookChoice(int id)
        {
            using (var db = new ApplicationContext())
            {
                var user = db.Books.SingleOrDefault(x => x.Id == id);
            }
        }
        /// <summary>
        /// Метод для выбора всех объектов
        /// </summary>
        public void SelectAllObjects()
        {
            using (var db = new ApplicationContext())
            {
                var allUsersId = db.Books.ToList();
            }
        }
        /// <summary>
        /// Метод для добавления новой книги
        /// </summary>
        /// <param name="title"></param>
        /// <param name="date"></param>
        public void BookAdding(string title, DateTime date)
        {
            using(var db = new ApplicationContext())
            {
                var book = new Book { Title = title, Date = date };

                db.Books.Add(book);

                db.SaveChanges();
            }
        }
        /// <summary>
        /// Метод для удаления книги
        /// </summary>
        /// <param name="title"></param>
        public void DeleteBook(string title)
        {
            {
                using(var db = new ApplicationContext())
                {
                    db.Books.Remove(new Book { Title = title });

                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Метод для обновления даты книги
        /// </summary>
        /// <param name="date"></param>
        public void UpdateDateBook(DateOnly date)
        {
            using(var db = new ApplicationContext())
            {
                db.Update(date);

                db.SaveChanges();
            }
        }
        /// <summary>
        /// Получать список книг определенного жанра и вышедших между определенными годами.
        /// </summary>
        /// <param name="grane"></param>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        public void BookListToGenreAndYear(string grane, DateTime date1, DateTime date2)
        {
            using(var db = new ApplicationContext())
            {
                var resalt = db.Books.Where(u => u.Genre == grane).Where(x => x.Date >= date1 && x.Date <= date2).ToList();

                foreach (var item in resalt)
                {
                    Console.WriteLine(item);
                }
            }
        }
        /// <summary>
        /// Получать количество книг определенного автора в библиотеке.
        /// </summary>
        /// <param name="name"></param>
        public void CountBookAutor(string name)
        {
            using(var db = new ApplicationContext())
            {
                var resalt = db.Books.Where(x => x.Autor == name).Count();

                if (resalt != null)
                {
                Console.WriteLine($"Книг автора: {resalt}");
                }
                else { Console.WriteLine("Автор не найден"); }
            }
        }
        /// <summary>
        /// Получать количество книг определенного жанра в библиотеке.
        /// </summary>
        /// <param name="genre"></param>
        public void CountBookGenre(string genre)
        {
            using(var db = new ApplicationContext())
            {
                var resalt = db.Books.Where(x => x.Genre == genre).Count();

                if (resalt != null)
                {
                    Console.WriteLine($"Книг данного жанра: {resalt}");
                }
                else { Console.WriteLine("Книг данного жанра не найдено!"); }
            }
        }
        /// <summary>
        /// Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        /// </summary>
        /// <param name="autor"></param>
        /// <param name="title"></param>
        public void AllBook(string autor, string title)
        {
            using(var db = new ApplicationContext())
            {
                var resalt = db.Books.All(x => x.Autor == autor && x.Title == title);

                if (resalt == true)
                {
                    Console.WriteLine("Данная книга имеется");
                }
                else { Console.WriteLine("Данная книга отсутствует"); }
            }
        }
        /// <summary>
        /// Получение последней вышедшей книги.
        /// </summary>
        public void LastBook()
        {
            using(var db = new ApplicationContext())
            {
                var resalt = db.Books.Select(x => x.Date).Last();

                Console.WriteLine(resalt);
            }
        }
        /// <summary>
        /// Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        /// </summary>
        public void ListBooksAsc()
        {
            using(var db = new ApplicationContext())
            {
                var resalt = db.Books.OrderBy(x => x.Title).ToList();

                foreach (var item in resalt)
                {
                    Console.WriteLine(item);
                }
            }
        }
        /// <summary>
        /// Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        /// </summary>
        public void ListBooksDateDesc()
        {
            using(var db = new ApplicationContext())
            {
                var resalt = db.Books.OrderByDescending(x => x.Date).ToList();

                foreach (var item in resalt)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
