namespace GenericArrayCreator
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            string[] words = ArrayCreator<string>.Create(5, "Prakash");
            int[] numbers = ArrayCreator<int>.Create(10, 1);
            foreach (var w in words)
            {
                Console.WriteLine(w);
            }
        }
    }
}
