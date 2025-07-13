namespace DevBook.API.Data;

public interface IUnitOfWork
{
    public Task Commit();
}
