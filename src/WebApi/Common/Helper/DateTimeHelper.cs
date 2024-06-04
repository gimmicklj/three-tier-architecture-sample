namespace WebApi.Common.Helper;

public static class DateTimeHelper
{
    public static DateTime StampToDateTime(string timeStamp)
    {
        DateTime dateTimeStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
        var lTime = long.Parse(timeStamp + "0000000");
        var toNow = new TimeSpan(lTime);
        return dateTimeStart.Add(toNow);
    }
    
    public static int DateTimeToStamp(DateTime time)
    {
        var startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
        return (int)(time - startTime).TotalSeconds;
    }
}