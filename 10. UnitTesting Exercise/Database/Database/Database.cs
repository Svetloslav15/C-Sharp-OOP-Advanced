namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Database
    {
        private int[] integers = new int[16];
        private int size;
        
        public int Size => this.size;
        public Database(params int[] ints)
        {
            this.people = new List<Person>();
            this.size = 0;
            this.SetInitialElements(ints);
        }
        public Database()
        {
            this.size = 0;
        }
        public void Add(int el)
        {
            if (this.size >= 16)
            {
                throw new InvalidOperationException("There is not enough space!");
            }
            this.integers[size++] = el;
        }
        private void SetInitialElements(params int[] elements)
        {
            if (elements.Length > 16)
            {
                throw new InvalidOperationException("Invalid Capacity!");
            }

            elements.CopyTo(this.integers, 0);
            this.size = elements.Length;
        }
        public int Remove()
        {
            if (size <= 0)
            {
                throw new InvalidOperationException("Cannot remove!");
            }
            return this.integers[--size];
        }
        public int[] Fetch()
        {
            return this.integers;
        }
    }
}
