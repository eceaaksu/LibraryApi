using LibraryAPI.Dtos.Library;
using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace libraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LibraryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibraryResponseDto>>> GetAll()
        {
            var libraries = await _context.Libraries
                .Select(l => new LibraryResponseDto
                {
                    Id = l.Id,
                    Name = l.Name,
                    Location = l.Location
                })
                .ToListAsync();

            return Ok(libraries);
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<LibraryResponseDto>> Create(LibraryCreateDto dto)
        {
            var library = new Library
            {
                Name = dto.Name,
                Location = dto.Location
            };

            _context.Libraries.Add(library);
            await _context.SaveChangesAsync();

            var response = new LibraryResponseDto
            {
                Id = library.Id,
                Name = library.Name,
                Location = library.Location
            };

            return Ok(response);
        }

    }
}
