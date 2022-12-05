using ReadingList.API.DataTransferObjects;

namespace ReadingList.API.Models
{
    public class CategoryViewModel
    {
        public List<CategoryDto> Categories { get; set; }
        public CategoryDto Category { get; set; }
    }
}
