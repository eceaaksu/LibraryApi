namespace LibraryAPI.Dtos.Student;

public class StudentCreateDto
{
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
