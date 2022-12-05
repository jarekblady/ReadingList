using ReadingList.API.DataTransferObjects;

namespace ReadingList.API.Models
{
    public class BookViewModel
    {
        public List<BookDto> Books { get; set; }
        public BookDto Book { get; set; }
    }
}
