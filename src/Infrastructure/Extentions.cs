 

namespace Infrastructure
{
    public  static class Extentions
    {
        public static string ToUTcDate(this DateTime dt)
        {
            return dt.ToUniversalTime().ToString();
        }

        public static DateTime FromUtc(this string utcvalue)
        {
            return DateTimeOffset.Parse(utcvalue).DateTime;
        }


    }
}
