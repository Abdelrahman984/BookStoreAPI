using BookStoreAPI.Models;
using BookStoreAPI.Repository;

namespace BookStoreAPI.Unit_Of_Works
{
    public class UnitOfWorks
    {
        BookStoreContext db;
        GenericRepository<Book> bookRepository;
        //GenericRepository<Catalog> catalogRepository;
        //GenericRepository<Author> authorRepository;
        //GenericRepository<Admin> adminRepository;
        //GenericRepository<Customer> customerRepository;
        //GenericRepository<Order> orderRepository;
        //GenericRepository<OrderDetails> orderDetailsRepository;
        public UnitOfWorks(BookStoreContext db, GenericRepository<Book> bookRepository)
        {
            this.db = db;
            this.bookRepository = bookRepository;
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
        //public GenericRepository<Catalog> CatalogRepository
        //{
        //    get
        //    {
        //        if (catalogRepository == null)
        //        {
        //            catalogRepository = new GenericRepository<Catalog>(db);
        //        }
        //        return catalogRepository;
        //    }
        //}
        //public GenericRepository<Author> AuthorRepository
        //{
        //    get
        //    {
        //        if (authorRepository == null)
        //        {
        //            authorRepository = new GenericRepository<Author>(db);
        //        }
        //        return authorRepository;
        //    }
        //}
        //public GenericRepository<Admin> AdminRepository
        //{
        //    get
        //    {
        //        if (adminRepository == null)
        //        {
        //            adminRepository = new GenericRepository<Admin>(db);
        //        }
        //        return adminRepository;
        //    }
        //}
        //public GenericRepository<Customer> CustomerRepository
        //{
        //    get
        //    {
        //        if (customerRepository == null)
        //        {
        //            customerRepository = new GenericRepository<Customer>(db);
        //        }
        //        return customerRepository;
        //    }
        //}
        //public GenericRepository<Order> OrderRepository
        //{
        //    get
        //    {
        //        if (orderRepository == null)
        //        {
        //            orderRepository = new GenericRepository<Order>(db);
        //        }
        //        return orderRepository;
        //    }
        //}
        //public GenericRepository<OrderDetails> OrderDetailsRepository
        //{
        //    get
        //    {
        //        if (orderDetailsRepository == null)
        //        {
        //            orderDetailsRepository = new GenericRepository<OrderDetails>(db);
        //        }
        //        return orderDetailsRepository;
        //    }
        //}
        //public void Save()
        //{
        //    db.SaveChanges();
        //}


    }
}
