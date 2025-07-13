namespace DevBook.API.Repositories.Book;

public interface IBookRepository
{
    public Task AddAsync(Entities.Book book);
    public Task Update(Entities.Book book);
    public Task DeleteAsync(Guid id);
    public Task<IList<Entities.Book>> GetAllAsync();
    public Task<Entities.Book?> GetByIdAsync(Guid id);
}
