namespace _10.Tuple
{
    public class Tuple<T, U>
    {
        public T item1 { get; set; }
        public U item2 { get; set; }

        public Tuple(T item1, U item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }
        public override string ToString()
        {
            return $"{item1} -> {item2}";
        }
    }
}
