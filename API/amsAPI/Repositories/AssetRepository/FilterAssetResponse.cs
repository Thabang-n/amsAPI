using amsAPI.Models.AssetModel;
using Domain.Models.AssetModel;

namespace amsAPI.Repositories.AssetRepository
{
    public class FilterAssetResponse
    {

        public static IQueryable<Asset> ApplyFiltering(IQueryable<Asset> query, AssetFilterParameters filtersParameters)
        {
            if (!string.IsNullOrEmpty(filtersParameters.filterOn) && !string.IsNullOrWhiteSpace(filtersParameters.filterQuery))
            {
                var filterOn = filtersParameters.filterOn;
                var filterQuery = filtersParameters.filterQuery;

                if (filterOn.Equals("Category", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(x => x.Category.CategoryName.Contains(filterQuery));
                }
                else if (filterOn.Equals("Country", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(x => x.Location.LocationName.Contains(filterQuery));
                }
                else if (filterOn.Equals("City", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(x => x.Location.LocationCity.Contains(filterQuery));
                }
                else if (filterOn.Equals("Status", StringComparison.OrdinalIgnoreCase))
                {
                    bool isAssigned = filterQuery.Equals("Assigned", StringComparison.OrdinalIgnoreCase);
                    query = query.Where(x => x.IsAssigned == isAssigned);
                }
                else if (filterOn.Equals("Search", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(x =>
                        x.SerialNumber.Contains(filterQuery) ||
                        x.Description.Contains(filterQuery) ||
                        x.Category.CategoryName.Contains(filterQuery) ||
                        x.Location.LocationName.Contains(filterQuery) ||
                        x.Brand.BrandName.Contains(filterQuery));
                }
            }

            return query;


        }
    }
}
