namespace _02.Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private IList<T> elements;
        private int internalIndex;

        public ListyIterator()
        {
        }

        public ListyIterator(params T[] elements)
        {
            this.Reset();
            this.elements = new List<T>(elements);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < this.elements.Count; index++)
            {
                yield return this.elements[index];
            }
        }
        public void PrintAll()
        {
            foreach (var item in this.elements)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public bool HasNext()
        {
            return this.internalIndex < this.elements.Count - 1;
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.internalIndex++;
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (this.elements.Count < 1)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Print(this.elements[internalIndex]);
        }

        public void Print<U>(params U[] value)
        {
            Console.WriteLine(value[0]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void Reset()
        {
            this.internalIndex = 0;
        }
    }
}