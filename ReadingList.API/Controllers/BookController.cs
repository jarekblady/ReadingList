using Microsoft.AspNetCore.Mvc;
using ReadingList.Service.DataTransferObjects;
using ReadingList.Service.Services.BookService;

namespace ReadingList.API.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetAllBook()
        {

            return Ok(_bookService.GetAllBook());
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBook(int id)
        {

            return Ok(_bookService.GetByIdBook(id));

        }

        [HttpPost]
        public ActionResult CreateBook(BookDto dto)
        {
            _bookService.CreateBook(dto);
            _bookService.UpdateOrderBy();

            return Ok("Success");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(BookDto dto)
        {

            _bookService.UpdateBook(dto);
            _bookService.UpdateOrderBy();
            return Ok("Success");
        }


        [HttpDelete("{id}")]

        public ActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            _bookService.UpdateOrderBy();

            return NoContent();

        }
        [HttpPut("IsRead/{id}")]
        public ActionResult UpdateIsRead(int id)
        {
            _bookService.UpdateIsRead(id);

            return Ok("Success");
        }

    }
}

