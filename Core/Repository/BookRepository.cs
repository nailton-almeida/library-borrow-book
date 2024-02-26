using LibraryProject.Core.Interface;
using LibraryProject.Core.Model;
using Microsoft.EntityFrameworkCore;


namespace LibraryProject.Core.Repository;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _repository;
    public BookRepository(AppDbContext context)
    {
        _repository = context;
    }


    public async Task<Book> Create(Book book)
    {
        _repository?.Books?.Add(book);
        await _repository.SaveChangesAsync();
        return book;
    }

    public async Task<bool> Delete(int Id)
    {
        var bookExist = _repository.Books.SingleOrDefault(x => x.Id == Id);
        var borrowedBook = _repository.BorrowedBooks.Any(p => p.BookId == Id && p.IsBorrowed == true);

        if (bookExist is not null && !borrowedBook)
        {
            _repository.Remove(bookExist);
            await _repository.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<IEnumerable<Book>> Get()
    {

        return await _repository.Books.AsNoTracking().ToListAsync();
    }

    public async Task<Book> Get(int Id)
    {

        return await _repository.Books.AsNoTracking().SingleOrDefaultAsync(book => book.Id == Id);


    }
}
