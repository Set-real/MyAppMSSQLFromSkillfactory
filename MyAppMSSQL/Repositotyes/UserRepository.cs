
using Microsoft.EntityFrameworkCore;
using MyAppMSSQL.Library;

namespace MyAppMSSQL.Repositotyes
{
    /// <summary>
    /// Репозиторий для работы с пользователем
    /// </summary>
    public class UserRepository
    {
        /// <summary>
        /// Метод для добавления нового пользователя по имени и имейлу
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public void CreateUser(string name, string email)
        {
            using(var db = new ApplicationContext())
            {
                var user = new User { Name = name, Email = email };

                db.Users.Add(user);

                db.SaveChanges();
            }            
        }
        /// <summary>
        /// Метод для удаления пользователся по имени
        /// </summary>
        /// <param name="name"></param>
        public void DelUser(string name)
        {
            using(var db =new ApplicationContext())
            {
                db.Remove(name);

                db.SaveChanges();
            }            
        }
        /// <summary>
        /// Метод для выбора пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        public void UserChoice(int id)
        {
            using (var db = new ApplicationContext()) 
            { 
                var user = db.Users.SingleOrDefault(x => x.Id == id);
            }
        }
        /// <summary>
        /// Метод для выбора всех объектов
        /// </summary>
        public void SelectAllObjects()
        {
            using(var db = new ApplicationContext())
            {
                var allUsersId = db.Users.ToList();
            }
        }
        /// <summary>
        /// Метод для обнавления имени пользователя
        /// </summary>
        /// <param name="id"></param>
        public void UsernameUpdate(int id)
        {
            using(var db = new ApplicationContext())
            {
                var user = db.Users.SingleOrDefault(x => x.Id == id);

                Console.WriteLine("Введите имя");

                string name = Console.ReadLine();

                if (user != null)
                {
                    user.Name = name;
                }
                else
                {
                    Console.WriteLine("Пользователь не найден");
                }
            }
        }
        /// <summary>
        /// Метод для добавления книги
        /// </summary>
        /// <param name="title"></param>
        /// <param name="user"></param>
        public void Books(string title, User user)
        {
            using(var db = new ApplicationContext())
            {
                var book = db.Books.Select(x => x.Title).Contains(title).ToString();

                if (book != null)
                {
                    user.BooksInHand = book;
                }
                else
                {
                    Console.WriteLine("Книга не найдена");
                }
            }
        }
        /// <summary>
        /// Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        /// </summary>
        /// <param name="title"></param>
        public void BoolBookInHand(string title)
        {
            using(var db = new ApplicationContext())
            {
                var resalt = db.Users.Select(x => x.BooksInHand == title).Contains(true).ToString();

                if (resalt != null)
                {
                    Console.WriteLine("Книга на руках у пользователя");
                }
                else { Console.WriteLine("Книга не найдена"); }
            }
        }
        /// <summary>
        /// Получать количество книг на руках у пользователя.
        /// </summary>
        public void CountBooksInHand(string name)
        {
            using(var db = new ApplicationContext())
            {
                var resalt = db.Users.Where(x => x.Name == name).Select(x => x.BooksInHand).Count();

                Console.WriteLine($"Книг у пользователя: {resalt}");
            }
        }
    }
}
