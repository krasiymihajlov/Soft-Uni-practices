namespace _02.BlackBoxInteger
{
    using _02BlackBoxInteger;
    using System;
    using System.Reflection;

    public class Program
    {
        public static void Main()
        {
            BlackBoxInt blackBox = (BlackBoxInt)Activator.CreateInstance(typeof(BlackBoxInt),
                BindingFlags.Instance | BindingFlags.NonPublic, null, new object[0], null);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split('_');
                string method = tokens[0];
                int value = int.Parse(tokens[1]);

                Console.WriteLine(GetInnerValue(blackBox, method, value));
            }
        }

        private static string GetInnerValue(BlackBoxInt blackBox, string method, int value)
        {
            MethodInfo getMethod = typeof(BlackBoxInt).GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic);

            getMethod.Invoke(blackBox, BindingFlags.Instance | BindingFlags.NonPublic,
               null, new object[] { value }, null);

            return typeof(BlackBoxInt).GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(blackBox).ToString();           
        }
    }
}
