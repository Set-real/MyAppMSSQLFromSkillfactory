using Microsoft.EntityFrameworkCore.Storage;
using MyAppMSSQL;
using MyAppMSSQL.Library;
using MyAppMSSQL.Repositotyes;

public class Program
{
    static void Main(string[] args)
    {
        using (var db = new ApplicationContext())
        {
            //Примеры методов
            var rep = new BookRepository();

            //Метод по поиску количества книг по имени автора
            string name = "Лев Николаевич Толстой";
            rep.CountBookAutor(name);

            var repUser = new UserRepository();
            string userName = "Bob";

            repUser.CountBooksInHand(userName);
        }
    }
}