namespace _10.Tuple
{
    using System;
    using System.Collections.Generic;

    public class Tuple<T, V>
    {
        private T item1;
        private V item2;

        public Tuple(T item1, V item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public T Item1
        {
            get { return this.item1; }
            private set
            {
                if (EqualityComparer<T>.Default.Equals(item1, default(T)))
                {
                    this.item1 = default(T);
                }

                this.item1 = value;
            }
        }

        public V Item2
        {
            get { return this.item2; }
            private set
            {
                if (EqualityComparer<V>.Default.Equals(item2, default(V)))
                {
                    this.item2 = default(V);
                }

                this.item2 = value;
            }
        }
        public override string ToString()
        {
            return $"{this.item1} -> {this.item2}";
        }
    }
}
