using Microsoft.AspNetCore.Mvc;
using ReadingList.API.DataTransferObjects;
using ReadingList.API.Models;
using ReadingList.API.Services.CategoryService;

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
        public ActionResult<IEnumerable<CategoryViewModel>> GetAllCategory()
        {
            var model = new CategoryViewModel();
            model.Categories = _categoryService.GetAllCategory();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryViewModel> GetCategory(/*[FromRoute]*/ int id)
        {
            var model = new CategoryViewModel();
            model.Category = _categoryService.GetByIdCategory(id);

            return Ok(model);

        }

        [HttpPost]
        public ActionResult CreateCategory(/*[FromBody]*/ CategoryViewModel model)
        {
            var dto = new CategoryDto()
            {
                Name = model.Category.Name,
            };
            _categoryService.CreateCategory(dto);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(/*[FromBody]*/ CategoryViewModel model/*, [FromRoute] int id*/)
        {
            var dto = new CategoryDto()
            {
                Id = model.Category.Id,
                //Id = id,
                Name = model.Category.Name,
            };

            _categoryService.UpdateCategory(dto);

            return Ok();
        }


        [HttpDelete("{id}")]

        public ActionResult DeleteCategory(/*[FromRoute]*/ int id)
        {
            _categoryService.DeleteCategory(id);


            return NoContent();

        }

    }
}
