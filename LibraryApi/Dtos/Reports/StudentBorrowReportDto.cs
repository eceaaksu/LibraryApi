namespace LibraryAPI.Dtos.Reports;

public class StudentBorrowReportDto
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = default!;
    public string BookTitle { get; set; } = default!;
    public DateTime BorrowDate { get; set; }
}
