namespace _11.Threeuple
{
    public class Threeuple<T, U, V>
    {
        public T item1 { get; set; }
        public U item2 { get; set; }
        public V item3 { get; set; }

        public Threeuple(T item1, U item2, V item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }
        public override string ToString()
        {
            return $"{item1} -> {item2} -> {item3}";
        }
    }
}