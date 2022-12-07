using ReadingList.API.DataTransferObjects;

namespace ReadingList.API.Models
{
    public class BookViewModel
    {
        //public List<BookDto> Books { get; set; }
        //public BookDto Book { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsRead { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
