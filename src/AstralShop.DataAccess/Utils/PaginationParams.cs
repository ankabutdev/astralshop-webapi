namespace AstralShop.DataAccess.Utils;

public class PaginationParams
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public int GetSkipCount()
    {
        return (PageNumber - 1) * PageSize;
    }
}
