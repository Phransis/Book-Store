using AutoMapper;
using PopePhransisBookStore.DTO;
using PopePhransisBookStore.Model;



namespace PopePhransisBookStore.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
