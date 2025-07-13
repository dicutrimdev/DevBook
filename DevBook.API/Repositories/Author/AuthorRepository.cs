using DevBook.API.Data;
using Microsoft.EntityFrameworkCore;

namespace DevBook.API.Repositories.Author;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(Entities.Author author)
    {
        if (author is null)
            throw new ArgumentNullException(nameof(author));

        await _context.Authors.AddAsync(author);
    }

    public async Task DeleteAsync(Guid id)
    {
        var author = await _context.Authors.FindAsync(id);

        if (author is null) return;

        _context.Authors.Remove(author);
    }

    public async Task<IList<Entities.Author>> GetAllAsync()
    {
        return await _context.Authors.Include(a => a.Books).ToListAsync();
    }

    public async Task<Entities.Author?> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id must not be empty.", nameof(id));

        return await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task Update(Entities.Author author)
    {
        if (author == null)
            throw new ArgumentNullException(nameof(author));

        _context.Authors.Update(author);

        return Task.CompletedTask;
    }
}
