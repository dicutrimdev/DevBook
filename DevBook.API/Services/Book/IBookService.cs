namespace DevBook.API.Services.Book;

public interface IBookService
{
    public Task<List<Entities.Book>> GetAllAsync();
    public Task<Entities.Book?> GetByIdAsync(Guid id);
    public Task CreateAsync(Entities.Book author);
    public Task UpdateAsync(Entities.Book author);
    public Task DeleteAsync(Guid id);
}
