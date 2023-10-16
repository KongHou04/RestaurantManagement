using System.Text.RegularExpressions;

namespace BUS.Handlers
{
    public static class DataChecker
    {
        public static bool CheckString(this string? str, int? maxLenght = null, bool isNullable = false, bool isAcceptNumber = true, char[]? invalidChars = null, string[]? invalidString = null)
        {
            if (!isNullable && str == null)
                return false;
            if (maxLenght != null && str?.Length > maxLenght)
                return false;
            if (!isAcceptNumber && str?.IndexOfAny(new char[]{'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'}) >= 0)
                return false;
            if (invalidChars != null && str?.IndexOfAny(invalidChars) >= 0)
                return false;
            if (invalidString != null && str != null)
            {
                foreach (var item in invalidString)
                {
                    if (str.Contains(item))
                        return false;
                }
            }
            return true;
        }

        public static bool CheckEmail(this string? email)
        {
            if (email == null)
                return false;
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (string.IsNullOrEmpty(email))
                return false;
            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }
    }
}