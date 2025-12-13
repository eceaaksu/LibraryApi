namespace LibraryAPI.Dtos.Library;

public class LibraryResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Location { get; set; } = default!;
}
