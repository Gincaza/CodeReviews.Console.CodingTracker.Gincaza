using System;
using System.Globalization;

namespace PresentationLayer;

public static class Validation
{
    private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

    public static bool IsValidDateTimeFormat(string input)
    {
        return DateTime.TryParseExact(
            input, 
            DateTimeFormat, 
            CultureInfo.InvariantCulture, 
            DateTimeStyles.None, 
            out _);
    }

    public static string GetRequiredDateTimeFormat()
    {
        return DateTimeFormat;
    }
}