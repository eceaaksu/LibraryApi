namespace LibraryAPI.Dtos.Reports;

public class LibraryBookCountReportDto
{
    public int LibraryId { get; set; }
    public string LibraryName { get; set; } = default!;
    public int BookCount { get; set; }
}
