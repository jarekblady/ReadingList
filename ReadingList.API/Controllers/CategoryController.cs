using Microsoft.AspNetCore.Mvc;
using ReadingList.Service.DataTransferObjects;
using ReadingList.Service.Services.CategoryService;

namespace ReadingList.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAllCategory()
        {

            return Ok(_categoryService.GetAllCategory());
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategory(int id)
        {

            return Ok(_categoryService.GetByIdCategory(id));

        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryDto dto)
        {
            _categoryService.CreateCategory(dto);

            return Ok("Success");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(CategoryDto dto)
        {

            _categoryService.UpdateCategory(dto);

            return Ok("Success");
        }


        [HttpDelete("{id}")]

        public ActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);


            return NoContent();

        }

    }
}
