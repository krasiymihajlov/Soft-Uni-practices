namespace _2.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main()
        {
            var calculatorExpression = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var stackNumbers = new Stack<string>(calculatorExpression.Reverse());

            while(stackNumbers.Count > 1)
            {
                var firstNumber = int.Parse(stackNumbers.Pop());
                var currentOperator = stackNumbers.Pop();
                var secondNumber = int.Parse(stackNumbers.Pop());

                switch(currentOperator)
                {
                    case "+" :
                        stackNumbers.Push((firstNumber + secondNumber).ToString());
                        break;
                    case "-":
                        stackNumbers.Push((firstNumber - secondNumber).ToString());
                        break;
                }
            }

            Console.WriteLine(stackNumbers.Pop());
            
        }
    }
}
