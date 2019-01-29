namespace MyRestful.Api
{
    public class PaginationBase
    {
        private int _pageSize = 10;
        public int PageIndex { get; set; } = 0;
        private int MAxPageSize { get; set; } = 100;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MAxPageSize ? MAxPageSize : value;
        }

        public string OrderBy { get; set; } = "Id";
    }
}