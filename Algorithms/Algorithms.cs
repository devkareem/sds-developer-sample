using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("The provided number must be positive.");

            return CalculateFactorial(n);
        }

        private static int CalculateFactorial(int number)
        {
            var result = 1;

            for (var incremental = 1; incremental <= number; incremental++)
                result *= incremental;

            return result;
        }

        public static string FormatSeparators(params string[] items)
        {
            if (items is null) return string.Empty;
            var (areLessThanThree, formattedString) = FormatIfLessThanThreeItems(items);
            if (areLessThanThree) return formattedString;

            var commaSeparatedList = BuildCommaSeparatedList(items);

            return $"{commaSeparatedList} and {items[^1]}";
        }

        private static string BuildCommaSeparatedList(IReadOnlyList<string> itemsList)
        {
            if (itemsList is null || !itemsList.Any())
                return string.Empty;

            var stringBuilder = new StringBuilder();

            for (var index = 0; index < itemsList.Count - 1; index++)
            {
                if (index > 0)
                    stringBuilder.Append(", ");

                stringBuilder.Append(itemsList[index]);
            }

            return stringBuilder.ToString();
        }

        private static (bool areLessThanThree, string formattedString) FormatIfLessThanThreeItems(IReadOnlyList<string> itemsList)
        {
            return itemsList.Count switch
            {
                0 => (true, string.Empty),
                1 => (true, itemsList[0]),
                2 => (true, $"{itemsList[0]} and {itemsList[1]}"),
                _ => (false, null)
            };
        }
    }
}