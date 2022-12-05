using Microsoft.AspNetCore.Mvc;
using ReadingList.API.DataTransferObjects;
using ReadingList.API.Models;
using ReadingList.API.Services.BookService;

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
            var model = new BookViewModel();
            model.Books = _bookService.GetAllBook();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public ActionResult<BookViewModel> GetBook(/*[FromRoute]*/ int id)
        {
            var model = new BookViewModel();
            model.Book = _bookService.GetByIdBook(id);

            return Ok(model);

        }

        [HttpPost]
        public ActionResult CreateBook(/*[FromBody]*/ BookViewModel model)
        {
            var dto = new BookDto()
            {
                Title = model.Book.Title,
                Author = model.Book.Author,
                Year = model.Book.Year,
                IsRead = model.Book.IsRead,
                IsPriority = model.Book.IsPriority,
                CategoryId = model.Book.CategoryId,
            };
            _bookService.CreateBook(dto);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(/*[FromBody]*/ BookViewModel model/*, [FromRoute] int id*/)
        {
            var dto = new BookDto()
            {
                Id = model.Book.Id,
                //Id = id,
                Title = model.Book.Title,
                Author = model.Book.Author,
                Year = model.Book.Year,
                IsRead = model.Book.IsRead,
                IsPriority = model.Book.IsPriority,
                CategoryId = model.Book.CategoryId,
            };

            _bookService.UpdateBook(dto);

            return Ok(model);
        }


        [HttpDelete("{id}")]

        public ActionResult DeleteBook(/*[FromRoute]*/ int id)
        {
            _bookService.DeleteBook(id);


            return NoContent();

        }

    }
}

