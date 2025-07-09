using amsAPI.Models.AssetModel;
using Domain.Models.AssetModel;

namespace amsAPI.Repositories.AssetRepository
{
    public class SortAssetResponse
    {

        public static IQueryable<Asset> SortAsset(IQueryable<Asset> query, AssetFilterParameters filtersParameters)
        {
            if (!string.IsNullOrWhiteSpace(filtersParameters.SortBy))
            {
                var sortBy = filtersParameters.SortBy;
                var isAscending = filtersParameters.isAscending;

                if (sortBy.Equals("DateCreated", StringComparison.OrdinalIgnoreCase))
                {
                    query = isAscending
                        ? query.OrderBy(a => a.DateCreated)
                        : query.OrderByDescending(a => a.DateCreated);
                }
                else if (sortBy.Equals("Status", StringComparison.OrdinalIgnoreCase))
                {
                    query = isAscending
                        ? query.OrderBy(a => a.IsAssigned)
                        : query.OrderByDescending(a => a.IsAssigned);
                }
            }

            return query;
        }
    }
}
