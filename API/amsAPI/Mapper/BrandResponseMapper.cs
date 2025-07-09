using Domain.Models.BrandModel;

namespace amsAPI.Mapper
{
    public class BrandResponseMapper
    {
        public static List<BrandDto> ToListDto(List<Brand> brand)
        {
            return brand.Select(brand => new BrandDto
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,

            }).ToList();
        }


        public static BrandDto ToDto(Brand brand)
        {
            return new BrandDto()
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
            };
        }

    }
}
