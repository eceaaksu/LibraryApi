using LibraryAPI.Dtos.StudentBook;
using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentBookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentBookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/studentbook
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentBookResponseDto>>> GetAll()
        {
            var result = await _context.StudentBooks
                .Select(sb => new StudentBookResponseDto
                {
                    Id = sb.Id,
                    StudentId = sb.StudentId,
                    BookId = sb.BookId,
                    BorrowDate = sb.BorrowDate
                })
                .ToListAsync();

            return Ok(result);
        }

        // POST api/studentbook (Borrow)
        [HttpPost]
        public async Task<ActionResult<StudentBookResponseDto>> Borrow(BorrowCreateDto dto)
        {
            // Öğrenci var mı?
            var studentExists = await _context.Students
                .AnyAsync(s => s.Id == dto.StudentId);

            if (!studentExists)
                return BadRequest("Geçersiz StudentId.");

            // Kitap var mı?
            var bookExists = await _context.Books
                .AnyAsync(b => b.Id == dto.BookId);

            if (!bookExists)
                return BadRequest("Geçersiz BookId.");

            // Aynı kitap aynı öğrenciye tekrar verilmesin
            var alreadyBorrowed = await _context.StudentBooks
                .AnyAsync(sb =>
                    sb.StudentId == dto.StudentId &&
                    sb.BookId == dto.BookId);

            if (alreadyBorrowed)
                return BadRequest("Bu kitap bu öğrenciye zaten verilmiş.");

            var studentBook = new StudentBook
            {
                StudentId = dto.StudentId,
                BookId = dto.BookId,
                BorrowDate = DateTime.Now
            };

            _context.StudentBooks.Add(studentBook);
            await _context.SaveChangesAsync();

            return Ok(new StudentBookResponseDto
            {
                Id = studentBook.Id,
                StudentId = studentBook.StudentId,
                BookId = studentBook.BookId,
                BorrowDate = studentBook.BorrowDate
            });
        }

        // DELETE api/studentbook/{id}  (Return / İade)
        [HttpDelete("{id}")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var studentBook = await _context.StudentBooks.FindAsync(id);

            if (studentBook == null)
                return NotFound("Kayıt bulunamadı.");

            _context.StudentBooks.Remove(studentBook);
            await _context.SaveChangesAsync();

            return Ok("Kitap iade edildi.");
        }
    }
}
