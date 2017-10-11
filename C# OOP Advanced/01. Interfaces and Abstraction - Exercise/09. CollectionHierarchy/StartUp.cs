namespace _09.CollectionHierarchy
{
    using _09.CollectionHierarchy.Collections;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] amountOfStrings = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            AddCollection<string> addCollection = new AddCollection<string>();
            AddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            MyList<string> myList = new MyList<string>();

            for (int i = 0; i < amountOfStrings.Length; i++)
            {
                addCollection.Add(amountOfStrings[i]);
                addRemoveCollection.Add(amountOfStrings[i]);
                myList.Add(amountOfStrings[i]);
            }

            Console.WriteLine(addCollection);
            Console.WriteLine(addRemoveCollection);
            Console.WriteLine(myList);

            int removeElement = int.Parse(Console.ReadLine());
            for (int i = 0; i < removeElement; i++)
            {
                addRemoveCollection.Remove();
                myList.Remove();
            }

            Console.WriteLine(addRemoveCollection.RemoveCollection(removeElement));
            Console.WriteLine(myList.RemoveCollection(removeElement));
        }
    }
}
