using LibraryAPI.Dtos.Book;
using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResponseDto>>> GetAll()
        {
            var books = await _context.Books
                .Include(b => b.Library) 
                .Select(b => new BookResponseDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ISBN = b.ISBN,
                    LibraryId = b.LibraryId,
                    LibraryName = b.Library.Name 
                })
                .ToListAsync();

            return Ok(books);
        }

       
        [HttpGet("library/{libraryId}")]
        public async Task<ActionResult<IEnumerable<BookResponseDto>>> GetBooksByLibrary(int libraryId)
        {
            var books = await _context.Books
                .Include(b => b.Library)
                .Where(b => b.LibraryId == libraryId)
                .Select(b => new BookResponseDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ISBN = b.ISBN,
                    LibraryId = b.LibraryId,
                    LibraryName = b.Library.Name
                })
                .ToListAsync();

            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<BookResponseDto>> Create(BookCreateDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                LibraryId = dto.LibraryId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

           
            var library = await _context.Libraries.FindAsync(book.LibraryId);

            var response = new BookResponseDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                LibraryId = book.LibraryId,
                LibraryName = library?.Name ?? "Bilinmiyor"
            };

            return Ok(response);
        }
    }
}