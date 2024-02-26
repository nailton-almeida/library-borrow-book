using LibraryProject.Core.DTO;
using LibraryProject.Core.Interface;
using LibraryProject.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Core.Repository;

public class BorrowBookRepository : IBorrowBookRepository
{
    private readonly AppDbContext _repository;

    public BorrowBookRepository(AppDbContext repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BorrowBook>> Get()
    {
        return await _repository.BorrowedBooks.AsNoTracking().ToListAsync();
    }

    public async Task<bool> Create(BorrowBook borrowBook)
    {
        bool bookExist = _repository.Books.Any(p => p.Id == borrowBook.BookId);

        bool bookIsBorrowed = _repository.BorrowedBooks.Any(p => p.BookId == borrowBook.BookId && p.IsBorrowed == true);

        bool userHasBook = _repository.BorrowedBooks.Any(p => p.UserId == borrowBook.UserId && p.IsBorrowed == true);

        if (bookExist && !bookIsBorrowed && !userHasBook)
        {
            borrowBook.BorrowDate = DateTime.Now;
            borrowBook.ReturnBorrowDate = DateTime.Now.AddDays(7);

            _repository.BorrowedBooks.Add(borrowBook);
            await _repository.SaveChangesAsync();
            return true;

        }

        return false;
    }

    public async Task<bool> ReturnBorrow(int Id)
    {


        var borrow = await _repository.BorrowedBooks.SingleOrDefaultAsync(p => p.Id == Id);


        if (borrow != null && borrow.ReturnBorrowDate > DateTime.Now)
        {

            borrow.IsBorrowed = false;

            await _repository.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
