using Domain.Models.FeatureModel;

namespace amsAPI.Mapper
{
    public class FeatureResponseMapper
    {
        public static List<FeatureDto> ConvertToDto(List<Feature> features)
        {
            return features.Select(feature => new FeatureDto
            {
                FeatureId = feature.FeatureId,
                FeatureKey = feature.FeatureKey
            }).ToList();
        }
    }
}
