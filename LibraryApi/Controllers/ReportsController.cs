using LibraryAPI.Dtos.Reports;
using LibraryAPI.Dtos.Book;
using LibraryAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet("student-books/{studentId}")]
        public async Task<ActionResult<IEnumerable<BookResponseDto>>> GetBooksByStudent(int studentId)
        {
            var result = await _context.StudentBooks
                .Include(x => x.Book)
                .Where(x => x.StudentId == studentId)
                .Select(x => new BookResponseDto
                {
                    
                    Id = x.Id,
                    Title = x.Book.Title,
                    Author = x.Book.Author,
                    ISBN = x.Book.ISBN,
                    LibraryId = x.Book.LibraryId
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("library-books/{libraryId}")]
        public async Task<ActionResult<IEnumerable<LibraryBookCountReportDto>>> GetBooksByLibrary(int libraryId)
        {
            var result = await _context.Books
                .Where(b => b.LibraryId == libraryId)
                .GroupBy(b => new { b.LibraryId, b.Library.Name })
                .Select(g => new LibraryBookCountReportDto
                {
                    LibraryId = g.Key.LibraryId,
                    LibraryName = g.Key.Name,
                    BookCount = g.Count()
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("who-has-books")]
        public async Task<ActionResult<IEnumerable<StudentBorrowReportDto>>> WhoHasBooks()
        {
            var result = await _context.StudentBooks
                .Include(x => x.Student)
                .Include(x => x.Book)
                .Select(x => new StudentBorrowReportDto
                {
                    StudentId = x.StudentId,
                    StudentName = x.Student.FullName,
                    BookTitle = x.Book.Title,
                    BorrowDate = x.BorrowDate
                })
                .ToListAsync();

            return Ok(result);
        }
    }
}