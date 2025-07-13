namespace DevBook.API.Repositories.Author;

public interface IAuthorRepository
{
    public Task AddAsync(Entities.Author author);
    public Task Update(Entities.Author author);
    public Task DeleteAsync(Guid id);
    public Task<IList<Entities.Author>> GetAllAsync();
    public Task<Entities.Author?> GetByIdAsync(Guid id);
}
