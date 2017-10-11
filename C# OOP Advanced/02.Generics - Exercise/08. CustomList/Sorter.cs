namespace _08.CustomList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sorter
    {
        public static CustomList<T> Sort<T>(CustomList<T> customList)
            where T : IComparable<T>
        {
            List<T> temp = customList.List.OrderBy(x => x).ToList();
            return new CustomList<T>(temp);
        }
    }
}