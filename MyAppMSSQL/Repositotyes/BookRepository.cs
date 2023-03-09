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
            using (var db = new ApplicatuonContext())
            {
                var user = db.Books.SingleOrDefault(x => x.Id == id);
            }
        }
        /// <summary>
        /// Метод для выбора всех объектов
        /// </summary>
        public void SelectAllObjects()
        {
            using (var db = new ApplicatuonContext())
            {
                var allUsersId = db.Books.ToList();
            }
        }
        /// <summary>
        /// Метод для добавления новой книги
        /// </summary>
        /// <param name="title"></param>
        /// <param name="date"></param>
        public void BookAdding(string title, double date)
        {
            using(var db = new ApplicatuonContext())
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
                using(var db = new ApplicatuonContext())
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
            using(var db = new ApplicatuonContext())
            {
                db.Update(date);

                db.SaveChanges();
            }
        }        
    }
}
