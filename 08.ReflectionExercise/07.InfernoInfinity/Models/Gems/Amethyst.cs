namespace _07.InfernoInfinity.Models.Gems
{
    public class Amethyst
    {
        public int Strength { get; private set; }
        public int Agility { get; private set; }
        public int Vitality { get; private set; }

        public Amethyst()
        {
            this.Strength = 2;
            this.Agility = 8;
            this.Vitality = 4;
        }
    }
}