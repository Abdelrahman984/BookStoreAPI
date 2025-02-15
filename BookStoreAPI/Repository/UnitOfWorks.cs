using BookStoreAPI.Models;

namespace BookStoreAPI.Repository
{
    public class UnitOfWorks
    {
        BookStoreContext db;
        GenericRepository<Book> bookRepository;
        public UnitOfWorks(BookStoreContext db, GenericRepository<Book> bookRepository)
        {
            this.db = db;
            bookRepository = new GenericRepository<Book>(db);
        }
        public GenericRepository<Book> BookRepository
        {
            get
            {
                if (bookRepository == null)
                {
                    bookRepository = new GenericRepository<Book>(db);
                }
                return bookRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }


    }
}