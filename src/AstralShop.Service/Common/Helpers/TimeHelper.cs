using AstralShop.Domain.Constants;

namespace AstralShop.Service.Common.Helpers;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var dtTime = DateTime.UtcNow;
        dtTime.AddHours(TimeConstant.UTC);
        return dtTime;
    }
}
