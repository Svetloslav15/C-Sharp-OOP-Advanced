using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Scale<int> scale = new Scale<int>(4, 36);
            Console.WriteLine(scale.GetHeavier());
        }
    }
}
