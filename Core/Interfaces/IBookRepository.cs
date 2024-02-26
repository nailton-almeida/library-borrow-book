using LibraryProject.Core.Model;

namespace LibraryProject.Core.Interface;

public interface IBookRepository
{

    Task<IEnumerable<Book>> Get();
    Task<Book> Get(int Id);
    Task<Book> Create(Book book);
    Task<bool> Delete(int Id);


}
