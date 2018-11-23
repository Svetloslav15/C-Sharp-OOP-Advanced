namespace BoxOfT
{
    using System.Collections.Generic;

    public class Box<T>
    {
        private IList<T> list;

        public int Count => this.list.Count;

        public Box()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public T Remove()
        {
            var last = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return last;
        } 
    }
}
