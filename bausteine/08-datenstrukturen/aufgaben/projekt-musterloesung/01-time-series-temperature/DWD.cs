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

    public static TimeSeries ReadTemperature(string file)
    {
        string[] lines = File.ReadAllLines(file);
        List<double> values = new List<double>();
        DateTime d1 = DWD.ParseDate(lines[1].Split(";")[1].Trim());
        DateTime d2 = DWD.ParseDate(lines[2].Split(";")[1].Trim());

        foreach (string line in lines.Skip(1))
        {
            string[] entries = line.Split(";");
            double value = Double.Parse(entries[3]);
            values.Add(value);
        }

        return new TimeSeries(d1, d2 - d1, values.ToArray());
    }
}