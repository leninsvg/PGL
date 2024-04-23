namespace PGL.Model;

public class PageModel<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public long TotalItems { get; set; }
    public long TotalPages { get; set; }
    public List<T> Items { get; set; }
}