using Domain.Models.CategoryModel;

namespace amsAPI.Mapper
{
    public class CategoriesResponseMapper
    {
        public static List<CategoryDto> ConvertToDto(List<Category> categories)
        {
            return categories.Select(categories => new CategoryDto
            {
                CategoryId = categories.CategoryId,
                CategoryName = categories.CategoryName
            }).ToList();
        }
    }
}
