namespace _00.Test
{
    using System;   

    public class ObjectAndClasses
    {
        public static void Main()
        {
            var cancer = new Cancer();
            cancer.Color = "Blue";                        

            var cancer1 = new Cancer
            {
                Color = "White",                
                Name = "Stavri"            
            };
            Console.WriteLine(cancer.Talk());
            Console.ForegroundColor = ConsoleColor.DarkGreen;           
            Console.WriteLine(cancer1.Color);
            Console.ResetColor();
        }
    }
}
