using LibraryProject.Core.Model;

namespace LibraryProject.Core.Interface;

public interface IUserRepository
{
    Task<bool> Create(User User);
    Task<bool> Delete(int Id);
    Task<bool> Update(User User, int id);
}
