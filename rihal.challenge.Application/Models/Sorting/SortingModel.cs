namespace rihal.challenge.Application.Models.Sorting
{
    public class SortingModel<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public T OrderBy { get; set; }
        public OrderDirection OrderByDirection { get; set; }
    }
}
