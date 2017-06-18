namespace _01.Phonebook_Upgrate
{
    using System;
    using System.Collections.Generic;

    public class DictLambdaLinqExer
    {
        public static void Main()
        {
            var phoneNumbersDict = new SortedDictionary<string, string>();
            var inputPhoneNumber = Console.ReadLine();

            while (!inputPhoneNumber.Equals("END"))
            {
                var phoneNumberArr = inputPhoneNumber.Split(' ');
                string addNumber = phoneNumberArr[0];

                if (addNumber == "A")
                {
                    AddPhoneNumber(phoneNumbersDict, phoneNumberArr);
                }
                else if (addNumber == "S")
                {
                    SearchPhoneNumber(phoneNumbersDict, phoneNumberArr);
                }
                else if (addNumber == "ListAll")
                {
                    GetAllList(phoneNumbersDict);
                }

                inputPhoneNumber = Console.ReadLine();
            }
        }

        public static void SearchPhoneNumber(SortedDictionary<string, string> phoneDict, string[] phoneNumber)
        {
            var contact = phoneNumber[1];

            if (phoneDict.ContainsKey(contact))
            {
                Console.WriteLine($"{contact} -> {phoneDict[contact]}");
            }
            else
            {
                Console.WriteLine($"Contact {contact} does not exist.");
            }
        }

        public static void AddPhoneNumber(SortedDictionary<string, string> phoneNumbersDict, string[] contact)
        {
            string index = contact[1];
            string number = contact[2];
            phoneNumbersDict[index] = number;
        }

        public static void GetAllList(SortedDictionary<string, string> phoneDict)
        {            
            foreach (var num in phoneDict)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}
