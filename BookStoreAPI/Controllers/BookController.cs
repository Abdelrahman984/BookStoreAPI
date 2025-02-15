using BookStoreAPI.DTOs.BookDTOs;
using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        UnitOfWorks _unit;
        public BookController(UnitOfWorks _unit)
        {
            this._unit = _unit;
        }

        [HttpGet]
        public IActionResult SelectAllBooks()
        {
            List<Book> books = _unit.BookRepository.SelectAll();
            List<DisplayBookDTO> booksDTO = new List<DisplayBookDTO>();
            foreach (var book in books)
            {
                DisplayBookDTO bookDTO = new DisplayBookDTO()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = book.Price,
                    Stock = book.Stock,
                    PublishDate = book.PublishDate,
                    AuthorName = book._Author.FullName,
                    CatalogName = book._Catalog.Name
                };
                booksDTO.Add(bookDTO);
            }
            return Ok(booksDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            Book book = _unit.BookRepository.SelectById(id);
            if (book == null)
            {
                return NotFound();
            }
            DisplayBookDTO bookDTO = new DisplayBookDTO()
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                Stock = book.Stock,
                PublishDate = book.PublishDate,
                AuthorName = book._Author.FullName,
                CatalogName = book._Catalog.Name
            };
            return Ok(bookDTO);
        }

        [HttpPost]
        public IActionResult AddBook(AddBookDTO bookDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Book book = new Book()
            {
                Title = bookDTO.Title,
                Price = bookDTO.Price,
                Stock = bookDTO.Stock,
                PublishDate = bookDTO.PublishDate,
                AuthorId = bookDTO.AuthorId,
                CatalogId = bookDTO.CatalogId
            };
            _unit.BookRepository.Add(book);
            _unit.Save();
            return CreatedAtAction("GetBookById", new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, AddBookDTO bookDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Book book = _unit.BookRepository.SelectById(id);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = bookDTO.Title;
            book.Price = bookDTO.Price;
            book.Stock = bookDTO.Stock;
            book.PublishDate = bookDTO.PublishDate;
            book.AuthorId = bookDTO.AuthorId;
            book.CatalogId = bookDTO.CatalogId;
            _unit.BookRepository.Update(book);
            _unit.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            Book book = _unit.BookRepository.SelectById(id);
            if (book == null)
            {
                return NotFound();
            }
            _unit.BookRepository.Delete(id);
            _unit.Save();
            return NoContent();
        }
    }
}