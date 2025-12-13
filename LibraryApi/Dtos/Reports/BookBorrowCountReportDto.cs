namespace LibraryAPI.Dtos.Reports;

public class BookBorrowCountReportDto
{
    public int BookId { get; set; }
    public string BookTitle { get; set; } = default!;
    public int BorrowCount { get; set; }
}
