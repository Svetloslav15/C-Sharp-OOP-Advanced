namespace BoxOfT
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(2);
            box.Add(6);
            box.Remove();

            Box<string> box1 = new Box<string>();
            box1.Add("sdf");
        }
    }
}
