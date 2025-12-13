namespace LibraryAPI.Dtos.StudentBook;

public class StudentBookResponseDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int BookId { get; set; }
    public DateTime BorrowDate { get; set; }
}
