namespace _12.LittleJohn
{
    using System;
    using System.Text;

    public class LittleJohn
    {
        public static void Main()
        {
            int decNumber = int.Parse(GetArrow());
            string binary = Convert.ToString(decNumber, 2);
            string reverseBinaryNumber = ReverseAString(binary);
            var concatString = binary + reverseBinaryNumber;
            string result = Convert.ToInt32(concatString, 2).ToString();
            Console.WriteLine(result);
        }

        private static string ReverseAString(string input)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }

            return sb.ToString();
        }

        private static string GetArrow()
        {
            string counter = string.Empty;

            int smallArrowCount = 0;
            int mediumArrowCount = 0;
            int largeArrowCount = 0;

            string smallArrow = ">----->";
            string mediumArrow = ">>----->";
            string largeArrow = ">>>----->>";

            for (int i = 0; i < 4; i++)
            {
                string input = Console.ReadLine();

                while (true)
                {
                    if (input.IndexOf(largeArrow) > -1)
                    {
                        largeArrowCount++;
                        int index = input.IndexOf(largeArrow);
                        input = input.Substring(0, index) + input.Substring(index + largeArrow.Length);
                    }
                    else if (input.IndexOf(mediumArrow) > -1)
                    {
                        mediumArrowCount++;
                        int index = input.IndexOf(mediumArrow);
                        input = input.Substring(0, index) + input.Substring(index + mediumArrow.Length);
                    }
                    else if (input.IndexOf(smallArrow) > -1)
                    {
                        smallArrowCount++;
                        int index = input.IndexOf(smallArrow);
                        input = input.Substring(0, index) + input.Substring(index + smallArrow.Length);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return counter = "" + smallArrowCount + mediumArrowCount + largeArrowCount;
        }
    }
}
