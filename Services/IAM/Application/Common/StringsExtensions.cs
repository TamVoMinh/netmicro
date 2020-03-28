using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Nmro.IAM.Application
{
    internal static class StringExtensions
    {
        public static string ToSpaceSeparatedString(this IEnumerable<string> list)
        {
            if (list == null)
            {
                return string.Empty;
            }
            var sb = new StringBuilder(100);
            foreach (var element in list)
            {
                sb.Append(element + " ");
            }
            return sb.ToString().Trim();
        }
        public static IEnumerable<string> FromSpaceSeparatedString(this string input)
        {
            input = input.Trim();
            return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        public static List<string> ParseScopesString(this string scopes)
        {
            if (scopes.IsMissing())
            {
                return null;
            }
            scopes = scopes.Trim();
            var parsedScopes = scopes.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
            if (parsedScopes.Any())
            {
                parsedScopes.Sort();
                return parsedScopes;
            }
            return null;
        }
        public static bool IsMissing(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        public static bool IsMissingOrTooLong(this string value, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return true;
            }
            if (value.Length > maxLength)
            {
                return true;
            }
            return false;
        }
        public static bool IsPresent(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
