using LibraryProject.Core.Model;

namespace LibraryProject.Core.Interface;

public interface IBorrowBookRepository
{
    Task<IEnumerable<BorrowBook>> Get();
    Task<bool> Create(BorrowBook borrowBook);
    Task<bool> ReturnBorrow(int Id);

}
