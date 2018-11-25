namespace _08.CustomListSorter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomList<T> : ICustomList<T>
        where T : IComparable<T>
    {
        private IList<T> list;
        public void Sort()
        {
            this.list = this.list.OrderBy(x => x).ToList();
        }
        public CustomList()
        {
            this.list = new List<T>();
        }
        public void Add(T element)
        {
            list.Add(element);
        }
        public void Print()
        {
            Console.WriteLine(string.Join(Environment.NewLine, this.list));
        }
        public bool Contains(T element)
        {
            return this.list.Contains(element);
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;
            foreach (var item in this.list)
            {
                if (this.Compare(item, element))
                {
                    count++;
                }
            }
            return count;
        }

        private bool Compare(T value1, T value2)
        {
            int num = (value1).CompareTo(value2);
            if (num > 0)
            {
                return true;
            }
            return false;
        }

        public T Max()
        {
            return this.list.Max();
        }

        public T Min()
        {
            return this.list.Min();
        }

        public T Remove(int index)
        {
            T value = this.list[index];
            this.list.RemoveAt(index);
            return value;
        }

        public void Swap(int index1, int index2)
        {
            T x = this.list[index1];
            this.list[index1] = this.list[index2];
            this.list[index2] = x;
        }
    }
}
