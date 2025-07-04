using Domain.Models.BrandModel;

namespace amsAPI.Mapper
{
    public class BrandResponseMapper
    {
        public static List<BrandDto> toDtoList(List<Brand> brands)
        {
            return brands.Select(brands => new BrandDto
            {
                BrandId = brands.BrandId,
                BrandName = brands.BrandName
            }).ToList();
        }
    }
}
