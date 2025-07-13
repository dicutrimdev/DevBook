using DevBook.API.Data;
using Microsoft.EntityFrameworkCore;

namespace DevBook.API.Repositories.Book;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(Entities.Book book)
    {
        if (book is null)
            throw new ArgumentNullException(nameof(book));

        await _context.Books.AddAsync(book);
    }

    public async Task DeleteAsync(Guid id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book is null) return;

        _context.Books.Remove(book);
    }

    public async Task<IList<Entities.Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Entities.Book?> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id must not be empty.", nameof(id));

        return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task Update(Entities.Book book)
    {
        if (book == null)
            throw new ArgumentNullException(nameof(book));

        _context.Books.Update(book);

        return Task.CompletedTask;
    }
}
