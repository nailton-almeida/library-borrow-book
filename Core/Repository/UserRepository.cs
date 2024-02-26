using AutoMapper;
using LibraryProject.Core.Interface;
using LibraryProject.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Core.Repository;

public class UserRepository : IUserRepository
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _repository;
    public UserRepository(AppDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _repository = context;

    }

    public async Task<bool> Create(User user)
    {
        var userExist = _repository.Users.Any(u => u.Email == user.Email);

        if (!userExist)
        {
            _repository.Users.Add(user);
            await _repository.SaveChangesAsync();
            return true;
        }

        return false;


    }

    public async Task<bool> Delete(int Id)
    {
        var user = _repository.Users.SingleOrDefault(x => x.Id == Id);
        var userHasBook = _repository.BorrowedBooks.Any(x => x.UserId == Id && x.IsBorrowed);

        if (user is not null && !userHasBook)
        {
            _repository.Remove(user);
            await _repository.SaveChangesAsync();
            return true;
        }
        return false;

    }

    public async Task<bool> Update(User user, int id)
    {
        var userExist = _repository.Users.SingleOrDefault(p => p.Id == id);

        if (userExist is not null)
        {
            userExist.Name = user.Name;
            userExist.Email = user.Email;
            _repository.SaveChanges();
            return true;
        }

        return false;
    }
}
