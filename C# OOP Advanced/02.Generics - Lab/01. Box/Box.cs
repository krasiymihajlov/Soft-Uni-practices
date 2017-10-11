using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private IList<T> box;

    public Box()
    {
        this.box = new List<T>();
    }

    public int Count => this.box.Count;

    public void Add(T element)
    {
        this.box.Add(element);
    }

    public T Remove()
    {
        var rem = box.LastOrDefault();
        this.box.RemoveAt(this.Count - 1);
        return rem;
    }
}

