namespace _10.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            var numberOfOperations = int.Parse(Console.ReadLine());
            var text = new StringBuilder();
            var stack = new Stack<string>();
            stack.Push(string.Empty);

            for (int i = 0; i < numberOfOperations; i++)
            {
                var currentLine = Console.ReadLine().Split();

                var command = currentLine[0];

                switch (command)
                {
                    case "1":
                        var currentText = currentLine[1];
                        text.Append(currentText);
                        stack.Push(text.ToString());
                        break;
                    case "2":
                        var count = int.Parse(currentLine[1]);
                        if (count <= text.Length)
                        {
                            text.Remove(text.Length - count, count);
                            stack.Push(text.ToString());
                        }
                        else
                        {
                            text.Clear();
                            stack.Push(text.ToString());
                        }

                        break;
                    case "3":
                        var print = int.Parse(currentLine[1]);
                        if (print <= text.Length)
                        {
                            Console.WriteLine(text[print - 1]);
                        }
                        break;
                    case "4":
                        if (stack.Count >= 0)
                        {
                            stack.Pop();
                            text.Clear();
                            text.Append(stack.Peek());
                        }

                        break;
                }
            }
        }
    }
}
