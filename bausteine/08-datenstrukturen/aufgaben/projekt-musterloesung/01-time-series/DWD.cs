public static class DWD
{
    public static DateTime ParseDate(string date)
    {
        int year = int.Parse(date.Substring(0, 4));
        int month = int.Parse(date.Substring(4, 2));
        int day = int.Parse(date.Substring(6, 2));
        int hour = int.Parse(date.Substring(8, 2));
        return new DateTime(year, month, day, hour, 0, 0);
    }
}