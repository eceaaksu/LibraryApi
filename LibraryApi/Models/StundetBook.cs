namespace LibraryAPI.Models;

public class StudentBook
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int BookId { get; set; }
    public DateTime BorrowDate { get; set; } = DateTime.Now;

    public Student? Student { get; set; }
    public Book? Book { get; set; }
}
