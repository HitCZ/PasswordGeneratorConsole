using PasswordGenerator.Other;
using System.Text;

namespace PasswordGeneratorConsole.Extensions
{
    public static class PasswordParametersExtensions
    {
        public static string GetParametersSummary(this PasswordParameters parameters)
        {
            if (parameters is null)
                return string.Empty;

            var sb = new StringBuilder();
            sb.AppendLine("Current Parameters:");
            sb.AppendLine(GetLengthSummary(parameters));
            sb.AppendLine(GetAlphabetSummary(parameters));
            sb.AppendLine(GetNumbersSummary(parameters));
            sb.AppendLine(GetSpecialCharsSummary(parameters));

            return sb.ToString();
        }

        public static string GetLengthSummary(this PasswordParameters parameters)
        {
            return $"Password Length: {parameters.PasswordLength}";
        }

        public static string GetNumbersSummary(this PasswordParameters parameters)
        {
            return $"Numbers: {parameters.ExactNumbersCount}";
        }

        public static string GetSpecialCharsSummary(this PasswordParameters parameters)
        {
            return $"Special characters: {parameters.ExactSpecialCharactersCount}";
        }

        public static string GetAlphabetSummary(this PasswordParameters parameters, bool? getLower = null)
        {
            var lowerSummary = $"Alphabet lower characters: {parameters.ExactLowerAlphabetCount}";
            var upperSummary = $"Alphabet upper characters: {parameters.ExactUpperAlphabetCount}";

            if (getLower is null)
                return string.Join("\n", lowerSummary, upperSummary);

            return getLower.Value ? lowerSummary : upperSummary;
        }
    }
}
