namespace amsAPI.Models.AssetModel
{
    public class AssetFilterParameters
    {
        public string? filterOn { get; set; } = null;
        public string? filterQuery { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool isAscending { get; set; } = true;
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;
    }
}
