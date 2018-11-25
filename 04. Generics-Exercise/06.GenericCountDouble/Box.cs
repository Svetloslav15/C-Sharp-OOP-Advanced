using System;

namespace _06.GenericCountDouble
{
    public class Box<T> where T : IComparable<T>
    {
        private T value;
        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"{this.value.GetType().FullName}: {this.value}";
        }

        public bool Compare(T currValue)
        {
            int num = (this.value).CompareTo(currValue);
            if (num > 0)
            {
                return true;
            }
            return false;
        }
    }
}
