namespace LibraryAPI.Dtos.Book;

public class BookCreateDto
{
    public string Title { get; set; } = default!;
    public string Author { get; set; } = default!;
    public string ISBN { get; set; } = default!;
    public int LibraryId { get; set; }
}
