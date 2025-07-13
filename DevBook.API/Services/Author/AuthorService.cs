using DevBook.API.Data;
using DevBook.API.Repositories.Author;

namespace DevBook.API.Services.Author;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(
        IUnitOfWork unitOfWork, 
        IAuthorRepository authorRepository)
    {
        _unitOfWork = unitOfWork;
        _authorRepository = authorRepository;
    }

    public async Task CreateAsync(Entities.Author author)
    {
        await _authorRepository.AddAsync(author);
        await _unitOfWork.Commit();
    }

    public async Task DeleteAsync(Guid id)
    {
        await _authorRepository.DeleteAsync(id);
        await _unitOfWork.Commit();
    }

    public async Task<List<Entities.Author>> GetAllAsync()
    {
        return (await _authorRepository.GetAllAsync()).ToList();
    }

    public async Task<Entities.Author?> GetByIdAsync(Guid id)
    {
        return await _authorRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Entities.Author author)
    {
        await _authorRepository.Update(author);
        await _unitOfWork.Commit();
    }
}
