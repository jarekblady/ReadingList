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
        public ActionResult<BookViewModel> GetBook(/*[FromRoute]*/ int id)
        {

            return Ok(_bookService.GetByIdBook(id));

        }

        [HttpPost]
        public ActionResult CreateBook(/*[FromBody]*/ BookViewModel model)
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

            return Ok("Success");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(/*[FromBody]*/ BookViewModel model/*, [FromRoute] int id*/)
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

            return Ok("Success");
        }


        [HttpDelete("{id}")]

        public ActionResult DeleteBook(/*[FromRoute]*/ int id)
        {
            _bookService.DeleteBook(id);


            return NoContent();

        }

    }
}

