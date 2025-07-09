using Domain.Models.CategoryModel;

namespace amsAPI.mapper
{
    public class CategoryResponseMapper
    {
        public static List<CategoryDto> ListToDto(List<Category> category)
        {
            return category.Select(category => new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,

            }).ToList();
        }
    }
}
