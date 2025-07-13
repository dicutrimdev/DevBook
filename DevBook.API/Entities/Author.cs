namespace DevBook.API.Entities;

public class Author
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IList<Book> Books { get; set; } = [];
}
