using Microsoft.AspNetCore.Mvc;
using ReadingList.Service.DataTransferObjects;
using ReadingList.API.Models;
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
        public ActionResult<IEnumerable<CategoryViewModel>> GetAllCategory()
        {
            //var model = new CategoryViewModel();
            //model.Categories = _categoryService.GetAllCategory();

            return Ok(_categoryService.GetAllCategory());
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryViewModel> GetCategory(/*[FromRoute]*/ int id)
        {
            //var model = new CategoryViewModel();
            //model.Category = _categoryService.GetByIdCategory(id);

            return Ok(_categoryService.GetByIdCategory(id));

        }

        [HttpPost]
        public ActionResult CreateCategory(/*[FromBody]*/ CategoryViewModel model)
        {
            var dto = new CategoryDto()
            {
                Name = model.Name,
            };
            _categoryService.CreateCategory(dto);

            return Ok("Success");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(/*[FromBody]*/ CategoryViewModel model/*, [FromRoute] int id*/)
        {
            var dto = new CategoryDto()
            {
                Id = model.Id,
                //Id = id,
                Name = model.Name,
            };

            _categoryService.UpdateCategory(dto);

            return Ok("Success");
        }


        [HttpDelete("{id}")]

        public ActionResult DeleteCategory(/*[FromRoute]*/ int id)
        {
            _categoryService.DeleteCategory(id);


            return NoContent();

        }

    }
}
