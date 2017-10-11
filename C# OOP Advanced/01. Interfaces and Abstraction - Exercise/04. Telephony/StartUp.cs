using System;

namespace _04.Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            ICallable phone = new Smartphone(phoneNumbers, sites);
            IBrowseable site = new Smartphone(phoneNumbers, sites);

            Console.WriteLine(phone.CallNumbers());
            Console.WriteLine(site.Browsing());
        }
    }
}
