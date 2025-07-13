using DevBook.API.Entities;

namespace DevBook.API.Repositories;

public interface IAuthorRepository
{
    public Task AddAsync(Author author);
    public Task Update(Author author);
    public Task DeleteAsync(Guid id);
    public Task<IList<Author>> GetAllAsync();
    public Task<Author?> GetByIdAsync(Guid id);
}
