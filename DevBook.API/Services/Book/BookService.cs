using DevBook.API.Data;
using DevBook.API.Repositories.Book;

namespace DevBook.API.Services.Book;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;

    public BookService(
        IUnitOfWork unitOfWork,
        IBookRepository bookRepository)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
    }

    public async Task CreateAsync(Entities.Book book)
    {
        await _bookRepository.AddAsync(book);
        await _unitOfWork.Commit();
    }

    public async Task DeleteAsync(Guid id)
    {
        await _bookRepository.DeleteAsync(id);
        await _unitOfWork.Commit();
    }

    public async Task<List<Entities.Book>> GetAllAsync()
    {
        return (await _bookRepository.GetAllAsync()).ToList();
    }

    public async Task<Entities.Book?> GetByIdAsync(Guid id)
    {
        return await _bookRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Entities.Book book)
    {
        await _bookRepository.Update(book);
        await _unitOfWork.Commit();
    }
}
