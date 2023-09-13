using Library1.DTO.BookDtos;

namespace Library1.DTO.GenreDtos
{
    public class GetGenreDto
    {
       
        
            public int Id { get; set; } 
            public string Name { get; set; }

         public   List<BookDto> bookDtos { get; set; }
        
    }
}
