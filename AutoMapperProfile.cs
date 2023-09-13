using AutoMapper;
using Library1.DTO.AuthorDto;
using Library1.DTO.AuthorPersonalInfoDtos;
using Library1.DTO.BookDtos;
using Library1.EntityModels;

namespace Library1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap< AuthorDto, Author>();
            CreateMap<AuthorPersonalInfoDto, AuthorPersonallInfo>();
            CreateMap< AuthorPersonallInfo, AuthorPersonalInfoDto>();

            CreateMap<GetAuthorDto, Author>();

            CreateMap< Author, GetAuthorDto>();

            CreateMap<GetbookDto, Book>();

            CreateMap<Book, GetbookDto>();




        }
    }
}
