namespace _07.InfernoInfinity.Models.Gems
{
    public class Ruby
    {
        public int Strength { get; private set; }
        public int Agility { get; private set; }
        public int Vitality { get; private set; }

        public Ruby()
        {
            this.Strength = 7;
            this.Agility = 2;
            this.Vitality = 5;
        }
    }
}
