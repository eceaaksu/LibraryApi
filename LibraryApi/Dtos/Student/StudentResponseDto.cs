namespace LibraryAPI.Dtos.Student;

public class StudentResponseDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
}
