namespace AstralShop.WebApi.Helpers;

public static class AppSettingHelper
{
    public static string GetLogFilePath()
    {
        var parentDirectory = Directory.GetCurrentDirectory();
        string logFilePath = Path.Combine(parentDirectory, @"logs\logs.log");
        return logFilePath;
    }
}