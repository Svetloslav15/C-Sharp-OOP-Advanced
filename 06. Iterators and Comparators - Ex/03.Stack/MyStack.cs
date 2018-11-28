namespace _03.Stack
{
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using System.Collections;

    public class MyStack<T> : IEnumerable<T>
    {
        private IList<T> elements;
        public int Size => this.elements.Count;

        public MyStack(params T[] items)
        {
            this.elements = new List<T>(items);
        }
        public void Push(params T[] items)
        {
            foreach (var item in items)
            {
                this.elements.Add(item);
            }
        }

        public T Pop()
        {
            T currItem = elements.Last();
            this.elements.RemoveAt(this.elements.Count - 1);
            return currItem;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int index = this.elements.Count - 1; index >= 0; index--)
            {
                yield return this.elements[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}