using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class Scale<T> where T : IComparable<T>
    {
        private T left;
        private T right;

        public Scale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public T GetHeavier()
        {
            int num = (this.left).CompareTo(this.right);
            Console.WriteLine(num);
            if (num < 0)
            {
                return this.right;
            }
            if (num > 0)
            {
                return this.left;
            }
            return default(T);
        }
    }
}
