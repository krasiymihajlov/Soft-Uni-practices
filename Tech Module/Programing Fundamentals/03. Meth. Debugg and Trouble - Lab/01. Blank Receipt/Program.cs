namespace _01.Blank_Receipt
{
    using System;

    public class Blank_Receipt
    {
        public static void Main(string[] args)
        {
            PrintReciept();
        }

        public static void PrintreceiptHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }

        public static void PrintReceiptBody()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }

        public static void PrintReceiptFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("\u00A9 SoftUni");
        }

        public static void PrintReciept()
        {
            PrintreceiptHeader();
            PrintReceiptBody();
            PrintReceiptFooter();
        }
    }
}
