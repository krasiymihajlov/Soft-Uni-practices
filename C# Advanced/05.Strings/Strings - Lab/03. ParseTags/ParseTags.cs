namespace _03.ParseTags
{
    using System;

    public class ParseTags
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var startPattern = "<upcase>";
            var endPattern = "</upcase>";

            var startIndex = text.IndexOf(startPattern);

            while (startIndex != -1)
            {
                var endIndex = text.IndexOf(endPattern);

                if (endIndex == -1)
                {
                    break;
                }

                var toBeReplaced = text.Substring(startIndex, (endIndex + endPattern.Length) - startIndex);
                var replaced = toBeReplaced
                    .Replace(startPattern, string.Empty)
                    .Replace(endPattern, string.Empty)
                    .ToUpper();

                text = text.Replace(toBeReplaced, replaced);

                startIndex = text.IndexOf(startPattern);
            }

            Console.WriteLine(text);
        }
    }
}
