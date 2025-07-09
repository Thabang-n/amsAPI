using Domain.Models.FeatureModel;

namespace amsAPI.Mapper
{
    public class FeatureResponseMapper
    {
        public static List<FeatureDto> ToDtoList(List<Feature> feature)
        {
            return feature.Select(feature => new FeatureDto
            {
                FeatureId = feature.FeatureId,
                FeatureKey = feature.FeatureKey,    

            }).ToList();
        }
    }
}
