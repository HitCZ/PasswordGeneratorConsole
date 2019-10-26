namespace PasswordGeneratorConsole.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value) => value is null || value == string.Empty;
        public static bool IsNumber(this string value) => int.TryParse(value, out _);
    }
}
