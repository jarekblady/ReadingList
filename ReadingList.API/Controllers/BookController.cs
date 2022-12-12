using Microsoft.AspNetCore.Mvc;
using ReadingList.Service.DataTransferObjects;
using ReadingList.API.Models;
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
        public ActionResult<IEnumerable<BookViewModel>> GetAllBook()
        {

            return Ok(_bookService.GetAllBook());
        }

        [HttpGet("{id}")]
        public ActionResult<BookViewModel> GetBook(int id)
        {

            return Ok(_bookService.GetByIdBook(id));

        }

        [HttpPost]
        public ActionResult CreateBook(BookViewModel model)
        {
            var dto = new BookDto()
            {
                Title = model.Title,
                Author = model.Author,
                IsRead = model.IsRead,
                Order = model.Order,
                CategoryId = model.CategoryId,
            };
            _bookService.CreateBook(dto);
            _bookService.UpdateOrderBy();

            return Ok("Success");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(BookViewModel model)
        {
            var dto = new BookDto()
            {
                Id = model.Id,
                //Id = id,
                Title = model.Title,
                Author = model.Author,
                IsRead = model.IsRead,
                Order = model.Order,
                CategoryId = model.CategoryId,
            };

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

    }
}

