namespace _06.StrategyPattern
{
    using System.Collections.Generic;
    using System;

    public class NameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int num = x.Name.Length.CompareTo(y.Name.Length);
            if (num == 0)
            {
                num = x.Name.ToLower()[0].CompareTo(y.Name.ToLower()[0]);
            }
            return num;
        }
    }
}
