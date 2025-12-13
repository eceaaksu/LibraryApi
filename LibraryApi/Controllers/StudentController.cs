using LibraryAPI.Dtos.Student;
using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponseDto>> Register(StudentCreateDto dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(new StudentResponseDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<StudentResponseDto>> Login(StudentLoginDto dto)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(x =>
                    x.Email == dto.Email &&
                    x.Password == dto.Password);

            if (student == null)
                return Unauthorized("Email veya şifre hatalı.");

            return Ok(new StudentResponseDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email
            });
        }
    }
}
