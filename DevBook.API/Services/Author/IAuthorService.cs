namespace DevBook.API.Services.Author;

public interface IAuthorService
{
    public Task<List<Entities.Author>> GetAllAsync();
    public Task<Entities.Author?> GetByIdAsync(Guid id);
    public Task CreateAsync(Entities.Author author);
    public Task UpdateAsync(Entities.Author author);
    public Task DeleteAsync(Guid id);
}
