

namespace MyAppMSSQL.Library
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        //Автор книги
        public string Autor { get; set; } = string.Empty;
        //Жанр
        public string Genre { get; set; } = string.Empty;

        // Внешний ключ
        public int? UserId { get; set; }
        // Навигационное свойство
        public User? User { get; set; }
    }
}
