namespace GenericArrayCreator
{
    public static class ArrayCreator<T>
    {
        public static T[] Create(int length, T item)
        {
            T[] array = new T[length];
            for (int index = 0; index < length; index++)
            {
                array[index] = item;
            }
            return array;
        }
    }
}
