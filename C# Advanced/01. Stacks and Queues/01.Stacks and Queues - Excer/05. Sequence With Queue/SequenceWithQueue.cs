namespace _05.Sequence_With_Queue
{
    using System;
    using System.Collections.Generic;

    public class SequenceWithQueue
    {
        public static void Main()
        {
            var calculateSequence = new Queue<long>();
            var printCollection = new List<long>();

            var number = long.Parse(Console.ReadLine());

            printCollection.Add(number);
            calculateSequence.Enqueue(number);


            while (printCollection.Count < 50)
            {
                var currentSeq = calculateSequence.Dequeue();

                var seq1 = currentSeq + 1;

                printCollection.Add(seq1);
                calculateSequence.Enqueue(seq1);

                var seq2 = 2 * currentSeq + 1;
                printCollection.Add(seq2);
                calculateSequence.Enqueue(seq2);

                var seq3 = currentSeq + 2;
                printCollection.Add(seq3);
                calculateSequence.Enqueue(seq3);
            }

            for (int i = 0; i < 50; i++)
            {
                Console.Write(printCollection[i] + " ");
            }
        }
    }
}
