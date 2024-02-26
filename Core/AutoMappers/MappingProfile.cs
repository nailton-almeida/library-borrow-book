using AutoMapper;
using LibraryProject.Core.DTO;
using LibraryProject.Core.Model;

namespace LibraryProject.Core.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<BorrowBook, BorrowBookDTO>().ReverseMap();

        }
    }
}
