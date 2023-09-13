using Library1.DTO.AuthorPersonalInfoDtos;

namespace Library1.DTO.AuthorDto
{
    public class GetAuthorDto
    {
        public int Id { get; set; }
        public string FirsName { get; set; }

        public string LastName { get; set; }





        public AuthorPersonalInfoDto AuthorPersonalInfoDto { get; set; }
    }
}
