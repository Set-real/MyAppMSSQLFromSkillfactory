

namespace MyAppMSSQL.Library
{
    public class User
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } = string.Empty;
        public string BooksInHand { get; set; } = string.Empty;

        //Реализация модели "Один ко многим"
        public List<Book> Books { get; set;} = new List<Book>();
    }
}
