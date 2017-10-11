
namespace _01.GenericBoxOfString
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T> where T : IComparable<T>
    {
        private List<T> box;

        public Box()
        {
            this.box = new List<T>();
        }

        public void Add(T element)
        {
            this.box.Add(element);
        }

        public int ReturnCount(T element)
        {
            int count = 0;
            for (int i = 0; i < this.box.Count; i++)
            {
                if (this.box[i].CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public string ReturnCollection(int[] indexes)
        {
            StringBuilder sb = new StringBuilder();
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];
            T swap = this.box[firstIndex];
            this.box[firstIndex] = this.box[secondIndex];
            this.box[secondIndex] = swap;

            for (int i = 0; i < this.box.Count; i++)
            {
                sb.AppendLine($"{this.box[i].GetType().FullName}: {this.box[i]}");
            }

            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return $"{box.GetType().FullName}: {this.box}";
        }
    }
}
